# Swarms Client C# API Library

> [!NOTE]
> The Swarms Client C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://github.com/The-Swarm-Corporation/swarms-csharp/issues/new).

The Swarms Client C# SDK provides convenient access to the [Swarms Client REST API](https://docs.swarms.ai) from applications written in C#.

The REST API documentation can be found on [docs.swarms.ai](https://docs.swarms.ai)

## Installation

```bash
dotnet add package Swarms
```

## Requirements

This library requires .NET 8 or later.

> [!NOTE]
> The library is currently in **beta**. The requirements will be lowered in the future.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Swarms;

SwarmsClientClient client = new();

var response = await client.GetRoot();

Console.WriteLine(response);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Swarms;

// Configured using the SWARMS_API_KEY and SWARMS_CLIENT_BASE_URL environment variables
SwarmsClientClient client = new();
```

Or manually:

```csharp
using Swarms;

SwarmsClientClient client = new() { APIKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property  | Environment variable     | Required | Default value                                        |
| --------- | ------------------------ | -------- | ---------------------------------------------------- |
| `APIKey`  | `SWARMS_API_KEY`         | false    | -                                                    |
| `BaseUrl` | `SWARMS_CLIENT_BASE_URL` | true     | `"https://swarms-api-285321057562.us-east1.run.app"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = new("https://example.com"),
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .GetRoot();

Console.WriteLine(response);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Swarms Client API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.GetRoot` should be called with an instance of `ClientGetRootParams`, and it will return an instance of `Task<JsonElement>`.

## Error handling

The SDK throws custom unchecked exception types:

- `SwarmsClientApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                                   |
| ------ | ------------------------------------------- |
| 400    | `SwarmsClientBadRequestException`           |
| 401    | `SwarmsClientUnauthorizedException`         |
| 403    | `SwarmsClientForbiddenException`            |
| 404    | `SwarmsClientNotFoundException`             |
| 422    | `SwarmsClientUnprocessableEntityException`  |
| 429    | `SwarmsClientRateLimitException`            |
| 5xx    | `SwarmsClient5xxException`                  |
| others | `SwarmsClientUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `SwarmsClient4xxException`.

false

- `SwarmsClientIOException`: I/O networking errors.

- `SwarmsClientInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `SwarmsClientException`: Base class for all exceptions.

## Network options

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Swarms;

SwarmsClientClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with
        {
            Timeout = TimeSpan.FromSeconds(42)
        }
    )
    .GetRoot();

Console.WriteLine(response);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/The-Swarm-Corporation/swarms-csharp/issues) with questions, bugs, or suggestions.
