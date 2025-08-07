using System;
using System.Text.Json;
using System.Threading.Tasks;
using Agent = Swarms.Services.Agent;
using Client = Swarms.Services.Client;
using Health = Swarms.Services.Health;
using Http = System.Net.Http;
using Models = Swarms.Services.Models;
using ReasoningAgents = Swarms.Services.ReasoningAgents;
using Swarms = Swarms.Services.Swarms;

namespace Swarms;

public interface ISwarmsClientClient
{
    Http::HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    string? APIKey { get; init; }

    Health::IHealthService Health { get; }

    Agent::IAgentService Agent { get; }

    Models::IModelService Models { get; }

    Swarms::ISwarmService Swarms { get; }

    ReasoningAgents::IReasoningAgentService ReasoningAgents { get; }

    Client::IClientService Client { get; }

    /// <summary>
    /// Root
    /// </summary>
    Task<JsonElement> GetRoot(global::Swarms.Models.ClientGetRootParams parameters);
}
