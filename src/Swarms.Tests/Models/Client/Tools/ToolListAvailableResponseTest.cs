using System.Collections.Generic;
using Swarms.Models.Client.Tools;

namespace Swarms.Tests.Models.Client.Tools;

public class ToolListAvailableResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolListAvailableResponse { Status = "status", Tools = ["string"] };

        string expectedStatus = "status";
        List<string> expectedTools = ["string"];

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
    }
}
