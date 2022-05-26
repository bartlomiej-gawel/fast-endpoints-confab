using System.Reflection;
using System.Runtime.CompilerServices;
using Confab.Shared.Exceptions;
using Confab.Shared.Modules;
using Confab.Shared.Postgres;
using Confab.Shared.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Confab.Bootstrapper")]
namespace Confab.Shared;

internal static class Extensions
{
    public static IServiceCollection AddModularInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        IList<Assembly> assemblies,
        IList<IModule> modules)
    {
        services.AddErrorHandling();
        services.AddPostgres(configuration);
        services.AddHostedService<AppInitializer>();
        services.AddModuleDisabler(configuration);
        services.AddFastEndpoints();

        return services;
    }

    public static WebApplication UseModularInfrastructure(this WebApplication app)
    {
        app.UseErrorHandling();
        app.UseAuthorization();
        app.UseFastEndpoints();
        return app;
    }
}