using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Exceptions;
using Swarms.Models;
using Swarms.Services.Agent;
using Swarms.Services.Client;
using Swarms.Services.Health;
using Swarms.Services.Models;
using Swarms.Services.ReasoningAgents;
using Swarms.Services.Swarms;

namespace Swarms;

public sealed class SwarmsClientClient : ISwarmsClientClient
{
    readonly ClientOptions _options = new();

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

    public async Task<JsonElement> GetRoot(ClientGetRootParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<ClientGetRootParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<JsonElement>().ConfigureAwait(false);
    }

    public async Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(request.Method, request.Params.Url(this))
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this);
        using CancellationTokenSource cts = new(this.Timeout);
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
        catch (HttpRequestException e1)
        {
            throw new SwarmsClientIOException("I/O exception", e1);
        }
        if (!responseMessage.IsSuccessStatusCode)
        {
            try
            {
                throw SwarmsClientExceptionFactory.CreateApiException(
                    responseMessage.StatusCode,
                    await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)
                );
            }
            catch (HttpRequestException e)
            {
                throw new SwarmsClientIOException("I/O Exception", e);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }
        return new() { Message = responseMessage };
    }

    public SwarmsClientClient()
    {
        _health = new(() => new HealthService(this));
        _agent = new(() => new AgentService(this));
        _models = new(() => new ModelService(this));
        _swarms = new(() => new SwarmService(this));
        _reasoningAgents = new(() => new ReasoningAgentService(this));
        _client = new(() => new ClientService(this));
    }
}
