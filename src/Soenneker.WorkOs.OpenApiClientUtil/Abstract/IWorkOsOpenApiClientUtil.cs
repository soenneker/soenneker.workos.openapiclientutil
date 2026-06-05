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
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<WorkOsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
