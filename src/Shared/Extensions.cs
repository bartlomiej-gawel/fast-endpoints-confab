using System.Reflection;
using System.Runtime.CompilerServices;
using Confab.Shared.Auth;
using Confab.Shared.Endpoints;
using Confab.Shared.Exceptions;
using Confab.Shared.Modules;
using Confab.Shared.Postgres;
using Confab.Shared.Services;
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
        services.AddEndpoints();
        services.AddAuth(configuration);

        return services;
    }

    public static WebApplication UseModularInfrastructure(this WebApplication app)
    {
        app.UseErrorHandling();
        app.UseAuth();
        app.UseEndpoints();
        return app;
    }
}