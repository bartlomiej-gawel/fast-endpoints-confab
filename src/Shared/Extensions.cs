using System.Runtime.CompilerServices;
using Confab.Shared.Exceptions;
using Confab.Shared.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Confab.Bootstrapper")]
namespace Confab.Shared;

internal static class Extensions
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddErrorHandling();
        services.AddHostedService<AppInitializer>();
        services.AddFastEndpoints();
        return services;
    }

    public static WebApplication UseShared(this WebApplication app)
    {
        app.UseErrorHandling();
        app.UseAuthorization();
        app.UseFastEndpoints();
        return app;
    }
}