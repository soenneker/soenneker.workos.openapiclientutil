using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.WorkOs.HttpClients.Registrars;
using Soenneker.WorkOs.OpenApiClientUtil.Abstract;

namespace Soenneker.WorkOs.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class WorkOsOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="WorkOsOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddWorkOsOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddWorkOsOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IWorkOsOpenApiClientUtil, WorkOsOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="WorkOsOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddWorkOsOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddWorkOsOpenApiHttpClientAsSingleton()
                .TryAddScoped<IWorkOsOpenApiClientUtil, WorkOsOpenApiClientUtil>();

        return services;
    }
}
