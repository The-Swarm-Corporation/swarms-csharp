using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models;
using Swarms.Services.Agent;
using Swarms.Services.Client;
using Swarms.Services.Health;
using Swarms.Services.Models;
using Swarms.Services.ReasoningAgents;
using Swarms.Services.Swarms;

namespace Swarms;

public interface ISwarmsClientClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    string? APIKey { get; init; }

    IHealthService Health { get; }

    IAgentService Agent { get; }

    IModelService Models { get; }

    ISwarmService Swarms { get; }

    IReasoningAgentService ReasoningAgents { get; }

    IClientService Client { get; }

    /// <summary>
    /// Root
    /// </summary>
    Task<JsonElement> GetRoot(ClientGetRootParams parameters);
}
