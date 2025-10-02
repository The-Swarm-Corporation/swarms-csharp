using System;
using System.Net.Http;
using System.Text.Json;
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
    public HttpClient HttpClient { get; init; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("SWARMS_CLIENT_BASE_URL")
                ?? "https://swarms-api-285321057562.us-east1.run.app"
        )
    );
    public Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    Lazy<string?> _apiKey = new(() => Environment.GetEnvironmentVariable("SWARMS_API_KEY"));
    public string? APIKey
    {
        get { return _apiKey.Value; }
        init { _apiKey = new(() => value); }
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
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead)
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
