using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Shared.Endpoints;

internal static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        return services.AddFastEndpoints();
    }

    public static WebApplication UseEndpoints(this WebApplication app)
    {
        return app.UseFastEndpoints();
    }
}