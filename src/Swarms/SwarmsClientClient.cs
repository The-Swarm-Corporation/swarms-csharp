using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models;
using Swarms.Services;

namespace Swarms;

/// <inheritdoc/>
public sealed class SwarmsClientClient : ISwarmsClientClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    readonly Lazy<ISwarmsClientClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISwarmsClientClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<JsonElement> GetRoot(
        ClientGetRootParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetRoot(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    public void Dispose() => this.HttpClient.Dispose();

    public SwarmsClientClient()
    {
        _options = new();

        _withRawResponse = new(() => new SwarmsClientClientWithRawResponse(this._options));
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

/// <inheritdoc/>
public sealed class SwarmsClientClientWithRawResponse : ISwarmsClientClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public ISwarmsClientClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SwarmsClientClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IHealthServiceWithRawResponse> _health;
    public IHealthServiceWithRawResponse Health
    {
        get { return _health.Value; }
    }

    readonly Lazy<IAgentServiceWithRawResponse> _agent;
    public IAgentServiceWithRawResponse Agent
    {
        get { return _agent.Value; }
    }

    readonly Lazy<IModelServiceWithRawResponse> _models;
    public IModelServiceWithRawResponse Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<ISwarmServiceWithRawResponse> _swarms;
    public ISwarmServiceWithRawResponse Swarms
    {
        get { return _swarms.Value; }
    }

    readonly Lazy<IReasoningAgentServiceWithRawResponse> _reasoningAgents;
    public IReasoningAgentServiceWithRawResponse ReasoningAgents
    {
        get { return _reasoningAgents.Value; }
    }

    readonly Lazy<IClientServiceWithRawResponse> _client;
    public IClientServiceWithRawResponse Client
    {
        get { return _client.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> GetRoot(
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
        var response = await this.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw SwarmsClientExceptionFactory.CreateApiException(
                        response.StatusCode,
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
        int retryCount,
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
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
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
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
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
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is SwarmsClientIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public SwarmsClientClientWithRawResponse()
    {
        _options = new();

        _health = new(() => new HealthServiceWithRawResponse(this));
        _agent = new(() => new AgentServiceWithRawResponse(this));
        _models = new(() => new ModelServiceWithRawResponse(this));
        _swarms = new(() => new SwarmServiceWithRawResponse(this));
        _reasoningAgents = new(() => new ReasoningAgentServiceWithRawResponse(this));
        _client = new(() => new ClientServiceWithRawResponse(this));
    }

    public SwarmsClientClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
