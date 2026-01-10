using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Swarms;
using Swarms.Services.Swarms;

namespace Swarms.Services;

/// <inheritdoc/>
public sealed class SwarmService : ISwarmService
{
    readonly Lazy<ISwarmServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISwarmServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISwarmsClientClient _client;

    /// <inheritdoc/>
    public ISwarmService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SwarmService(this._client.WithOptions(modifier));
    }

    public SwarmService(ISwarmsClientClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SwarmServiceWithRawResponse(client.WithRawResponse));
        _batch = new(() => new BatchService(client));
    }

    readonly Lazy<IBatchService> _batch;
    public IBatchService Batch
    {
        get { return _batch.Value; }
    }

    /// <inheritdoc/>
    public async Task<SwarmCheckAvailableResponse> CheckAvailable(
        SwarmCheckAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CheckAvailable(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SwarmGetLogsResponse> GetLogs(
        SwarmGetLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetLogs(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SwarmRunResponse> Run(
        SwarmRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Run(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SwarmServiceWithRawResponse : ISwarmServiceWithRawResponse
{
    readonly ISwarmsClientClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISwarmServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SwarmServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SwarmServiceWithRawResponse(ISwarmsClientClientWithRawResponse client)
    {
        _client = client;

        _batch = new(() => new BatchServiceWithRawResponse(client));
    }

    readonly Lazy<IBatchServiceWithRawResponse> _batch;
    public IBatchServiceWithRawResponse Batch
    {
        get { return _batch.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SwarmCheckAvailableResponse>> CheckAvailable(
        SwarmCheckAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SwarmCheckAvailableParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SwarmCheckAvailableResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SwarmGetLogsResponse>> GetLogs(
        SwarmGetLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SwarmGetLogsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SwarmGetLogsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SwarmRunResponse>> Run(
        SwarmRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SwarmRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SwarmRunResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
