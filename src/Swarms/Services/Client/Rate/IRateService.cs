using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Client.Rate;

namespace Swarms.Services.Client.Rate;

public interface IRateService
{
    /// <summary>
    /// Get the rate limits and current usage for the user associated with the provided
    /// API key.
    /// </summary>
    Task<Dictionary<string, JsonElement>> GetLimits(RateGetLimitsParams parameters);
}
