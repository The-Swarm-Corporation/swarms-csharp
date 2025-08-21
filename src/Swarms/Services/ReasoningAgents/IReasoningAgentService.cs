using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.ReasoningAgents;

namespace Swarms.Services.ReasoningAgents;

public interface IReasoningAgentService
{
    /// <summary>
    /// Run a reasoning agent with the specified task.
    /// </summary>
    Task<Dictionary<string, JsonElement>> CreateCompletion(
        ReasoningAgentCreateCompletionParams? parameters = null
    );

    /// <summary>
    /// Get the types of reasoning agents available.
    /// </summary>
    Task<Dictionary<string, JsonElement>> ListTypes(
        ReasoningAgentListTypesParams? parameters = null
    );
}
