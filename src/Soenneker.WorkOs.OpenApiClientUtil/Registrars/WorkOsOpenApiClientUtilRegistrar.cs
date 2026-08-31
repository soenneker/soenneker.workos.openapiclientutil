using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.WorkOs.HttpClients.Registrars;
using Soenneker.WorkOs.OpenApiClientUtil.Abstract;

namespace Soenneker.WorkOs.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the cached WorkOS API client provider.
/// </summary>
public static class WorkOsOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the WorkOS API client provider as a singleton service.
    /// </summary>
    public static IServiceCollection AddWorkOsOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddWorkOsOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IWorkOsOpenApiClientUtil, WorkOsOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the WorkOS API client provider as a scoped service while retaining the singleton HTTP transport.
    /// </summary>
    public static IServiceCollection AddWorkOsOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddWorkOsOpenApiHttpClientAsSingleton()
                .TryAddScoped<IWorkOsOpenApiClientUtil, WorkOsOpenApiClientUtil>();

        return services;
    }
}
