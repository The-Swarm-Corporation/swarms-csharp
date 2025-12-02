using System.Collections.Generic;
using Swarms.Models.Swarms;

namespace Swarms.Tests.Models.Swarms;

public class SwarmCheckAvailableResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwarmCheckAvailableResponse { Success = true, SwarmTypes = ["string"] };

        bool expectedSuccess = true;
        List<string> expectedSwarmTypes = ["string"];

        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedSwarmTypes.Count, model.SwarmTypes.Count);
        for (int i = 0; i < expectedSwarmTypes.Count; i++)
        {
            Assert.Equal(expectedSwarmTypes[i], model.SwarmTypes[i]);
        }
    }
}
