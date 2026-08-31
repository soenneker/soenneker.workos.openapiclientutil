using Soenneker.WorkOs.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.WorkOs.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached WorkOS API client backed by the configured HTTP transport.
/// </summary>
public interface IWorkOsOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached WorkOS API client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured WorkOS API client.</returns>
    ValueTask<WorkOsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
