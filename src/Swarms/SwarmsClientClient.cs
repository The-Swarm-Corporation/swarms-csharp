using System;
using System.Text.Json;
using System.Threading.Tasks;
using Agent = Swarms.Services.Agent;
using Client = Swarms.Services.Client;
using Health = Swarms.Services.Health;
using Http = System.Net.Http;
using Models = Swarms.Models;
using ReasoningAgents = Swarms.Services.ReasoningAgents;
using Swarms = Swarms.Services.Swarms;

namespace Swarms;

public sealed class SwarmsClientClient : ISwarmsClientClient
{
    public Http::HttpClient HttpClient { get; init; } = new();

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

    readonly Lazy<Health::IHealthService> _health;
    public Health::IHealthService Health
    {
        get { return _health.Value; }
    }

    readonly Lazy<Agent::IAgentService> _agent;
    public Agent::IAgentService Agent
    {
        get { return _agent.Value; }
    }

    readonly Lazy<global::Swarms.Services.Models.IModelService> _models;
    public global::Swarms.Services.Models.IModelService Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<Swarms::ISwarmService> _swarms;
    public Swarms::ISwarmService Swarms
    {
        get { return _swarms.Value; }
    }

    readonly Lazy<ReasoningAgents::IReasoningAgentService> _reasoningAgents;
    public ReasoningAgents::IReasoningAgentService ReasoningAgents
    {
        get { return _reasoningAgents.Value; }
    }

    readonly Lazy<Client::IClientService> _client;
    public Client::IClientService Client
    {
        get { return _client.Value; }
    }

    public async Task<JsonElement> GetRoot(Models::ClientGetRootParams parameters)
    {
        using Http::HttpRequestMessage request = new(Http::HttpMethod.Get, parameters.Url(this));
        parameters.AddHeadersToRequest(request, this);
        using Http::HttpResponseMessage response = await this
            .HttpClient.SendAsync(request, Http::HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<JsonElement>(
            await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
            ModelBase.SerializerOptions
        );
    }

    public SwarmsClientClient()
    {
        _health = new(() => new Health::HealthService(this));
        _agent = new(() => new Agent::AgentService(this));
        _models = new(() => new global::Swarms.Services.Models.ModelService(this));
        _swarms = new(() => new Swarms::SwarmService(this));
        _reasoningAgents = new(() => new ReasoningAgents::ReasoningAgentService(this));
        _client = new(() => new Client::ClientService(this));
    }
}
