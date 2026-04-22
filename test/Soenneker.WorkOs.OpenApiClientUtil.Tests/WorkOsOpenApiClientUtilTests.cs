using Soenneker.WorkOs.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.WorkOs.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class WorkOsOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IWorkOsOpenApiClientUtil _openapiclientutil;

    public WorkOsOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IWorkOsOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
