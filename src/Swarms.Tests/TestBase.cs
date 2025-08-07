using System;
using Swarms;

namespace Swarms.Tests;

public class TestBase
{
    protected ISwarmsClientClient client;

    public TestBase()
    {
        client = new SwarmsClientClient()
        {
            BaseUrl = new Uri(
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010"
            ),
            APIKey = "My API Key",
        };
    }
}
