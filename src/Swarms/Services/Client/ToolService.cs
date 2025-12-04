using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Swarms.Core;
using Swarms.Models.Client.Tools;

namespace Swarms.Services.Client;

/// <inheritdoc/>
public sealed class ToolService : IToolService
{
    /// <inheritdoc/>
    public IToolService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ToolService(this._client.WithOptions(modifier));
    }

    readonly ISwarmsClientClient _client;

    public ToolService(ISwarmsClientClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ToolListAvailableResponse> ListAvailable(
        ToolListAvailableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ToolListAvailableParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ToolListAvailableResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
