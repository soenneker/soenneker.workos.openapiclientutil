using Soenneker.WorkOs.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.WorkOs.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class WorkOsOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IWorkOsOpenApiClientUtil _openapiclientutil;

    public WorkOsOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IWorkOsOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
