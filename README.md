# Swarms Client C# API Library

> [!NOTE]
> The Swarms Client C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/The-Swarm-Corporation/swarms-csharp/issues/new).

The Swarms Client C# SDK provides convenient access to the [Swarms Client REST API](https://docs.swarms.world/en/latest/) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [docs.swarms.world](https://docs.swarms.world/en/latest/).

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

// Configured using the SWARMS_API_KEY and SWARMS_CLIENT_BASE_URL environment variables
SwarmsClientClient client = new();

var response = await client.GetRoot();

Console.WriteLine(response);
```

## Client Configuration

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

## Requests and responses

To send a request to the Swarms Client API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.GetRoot` should be called with an instance of `ClientGetRootParams`, and it will return an instance of `Task<JsonElement>`.

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/The-Swarm-Corporation/swarms-csharp/issues) with questions, bugs, or suggestions.
