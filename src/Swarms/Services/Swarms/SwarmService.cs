using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Swarms.Models.Swarms;
using Batch = Swarms.Services.Swarms.Batch;

namespace Swarms.Services.Swarms;

public sealed class SwarmService : ISwarmService
{
    readonly ISwarmsClientClient _client;

    public SwarmService(ISwarmsClientClient client)
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
        using HttpRequestMessage webRequest = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<SwarmCheckAvailableResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<SwarmGetLogsResponse> GetLogs(SwarmGetLogsParams parameters)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<SwarmGetLogsResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<SwarmRunResponse> Run(SwarmRunParams parameters)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<SwarmRunResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
