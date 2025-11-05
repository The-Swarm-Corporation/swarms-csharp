using System;
using System.Net.Http;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Swarms;
using Swarms.Services.Swarms.Batch;

namespace Swarms.Services.Swarms;

public sealed class SwarmService : ISwarmService
{
    public ISwarmService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SwarmService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public SwarmService(ISwarmsClientClient client)
    {
        _client = client;
        _batch = new(() => new BatchService(client));
    }

    readonly Lazy<IBatchService> _batch;
    public IBatchService Batch
    {
        get { return _batch.Value; }
    }

    public async Task<SwarmCheckAvailableResponse> CheckAvailable(
        SwarmCheckAvailableParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<SwarmCheckAvailableParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SwarmCheckAvailableResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<SwarmGetLogsResponse> GetLogs(SwarmGetLogsParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<SwarmGetLogsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SwarmGetLogsResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<SwarmRunResponse> Run(SwarmRunParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<SwarmRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SwarmRunResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
