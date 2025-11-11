using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models;
using Swarms.Services;

namespace Swarms;

public sealed class SwarmsClientClient : ISwarmsClientClient
{
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }

    readonly ClientOptions _options;

    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    public Uri BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    public int MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    public TimeSpan Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    public string? APIKey
    {
        get { return this._options.APIKey; }
        init { this._options.APIKey = value; }
    }

    public ISwarmsClientClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SwarmsClientClient(modifier(this._options));
    }

    readonly Lazy<IHealthService> _health;
    public IHealthService Health
    {
        get { return _health.Value; }
    }

    readonly Lazy<IAgentService> _agent;
    public IAgentService Agent
    {
        get { return _agent.Value; }
    }

    readonly Lazy<IModelService> _models;
    public IModelService Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<ISwarmService> _swarms;
    public ISwarmService Swarms
    {
        get { return _swarms.Value; }
    }

    readonly Lazy<IReasoningAgentService> _reasoningAgents;
    public IReasoningAgentService ReasoningAgents
    {
        get { return _reasoningAgents.Value; }
    }

    readonly Lazy<IClientService> _client;
    public IClientService Client
    {
        get { return _client.Value; }
    }

    public async Task<JsonElement> GetRoot(
        ClientGetRootParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ClientGetRootParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this.Execute(request, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }

    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        if (this.MaxRetries <= 0)
        {
            return await ExecuteOnce(request, cancellationToken).ConfigureAwait(false);
        }

        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > this.MaxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > this.MaxRetries || !ShouldRetry(response)))
            {
                if (response.Message.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw SwarmsClientExceptionFactory.CreateApiException(
                        response.Message.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new SwarmsClientIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        using CancellationTokenSource timeoutCts = new(this.Timeout);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new SwarmsClientIOException("I/O exception", e);
        }
        return new() { Message = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (apiBackoff != null && apiBackoff < TimeSpan.FromMinutes(1))
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.Message.Headers.TryGetValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue.AsSpan(), out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.Message.Headers.TryGetValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue.AsSpan(), out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue.AsSpan(), out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.Message.Headers.TryGetValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return response.Message.StatusCode switch
        {
            // Retry on request timeouts
            HttpStatusCode.RequestTimeout
            or
            // Retry on lock timeouts
            HttpStatusCode.Conflict
            or
            // Retry on rate limits
            HttpStatusCode.TooManyRequests
            or
            // Retry internal errors
            >= HttpStatusCode.InternalServerError => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is SwarmsClientIOException;
    }

    public SwarmsClientClient()
    {
        _options = new();

        _health = new(() => new HealthService(this));
        _agent = new(() => new AgentService(this));
        _models = new(() => new ModelService(this));
        _swarms = new(() => new SwarmService(this));
        _reasoningAgents = new(() => new ReasoningAgentService(this));
        _client = new(() => new ClientService(this));
    }

    public SwarmsClientClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
