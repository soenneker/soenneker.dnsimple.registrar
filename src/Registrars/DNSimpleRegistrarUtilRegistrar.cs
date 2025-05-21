using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.DNSimple.OpenApiClientUtil.Registrars;
using Soenneker.DNSimple.Registrar.Abstract;

namespace Soenneker.DNSimple.Registrar.Registrars;

/// <summary>
/// A .NET typesafe implementation of DNSimple's Registrar API
/// </summary>
public static class DNSimpleRegistrarUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IDNSimpleRegistrarUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddDNSimpleRegistrarUtilAsSingleton(this IServiceCollection services)
    {
        services.AddDNSimpleOpenApiClientUtilAsSingleton().TryAddSingleton<IDNSimpleRegistrarUtil, DNSimpleRegistrarUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IDNSimpleRegistrarUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDNSimpleRegistrarUtilAsScoped(this IServiceCollection services)
    {
        services.AddDNSimpleOpenApiClientUtilAsSingleton().TryAddScoped<IDNSimpleRegistrarUtil, DNSimpleRegistrarUtil>();

        return services;
    }
}