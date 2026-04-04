using Soenneker.WorkOs.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.WorkOs.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IWorkOsOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<WorkOsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
