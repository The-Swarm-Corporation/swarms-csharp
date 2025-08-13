using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Swarms;
using Batch = Swarms.Services.Swarms.Batch;
using Swarms = Swarms;

namespace Swarms.Services.Swarms;

public sealed class SwarmService : ISwarmService
{
    readonly Swarms::ISwarmsClientClient _client;

    public SwarmService(Swarms::ISwarmsClientClient client)
    {
        _client = client;
        _batch = new(() => new Batch::BatchService(client));
    }

    readonly Lazy<Batch::IBatchService> _batch;
    public Batch::IBatchService Batch
    {
        get { return _batch.Value; }
    }

    public async Task<SwarmCheckAvailableResponse> CheckAvailable(
        SwarmCheckAvailableParams parameters
    )
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Swarms::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<SwarmCheckAvailableResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Swarms::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<SwarmGetLogsResponse> GetLogs(SwarmGetLogsParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Swarms::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<SwarmGetLogsResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Swarms::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<SwarmRunResponse> Run(SwarmRunParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Swarms::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<SwarmRunResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Swarms::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
