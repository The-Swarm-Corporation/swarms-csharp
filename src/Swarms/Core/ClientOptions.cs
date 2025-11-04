using System;
using System.Net.Http;

namespace Swarms.Core;

public struct ClientOptions()
{
    public HttpClient HttpClient { get; set; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("SWARMS_CLIENT_BASE_URL")
                ?? "https://swarms-api-285321057562.us-east1.run.app"
        )
    );
    public Uri BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    public bool ResponseValidation { get; set; } = false;

    public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(1);

    Lazy<string?> _apiKey = new(() => Environment.GetEnvironmentVariable("SWARMS_API_KEY"));
    public string? APIKey
    {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }
}
