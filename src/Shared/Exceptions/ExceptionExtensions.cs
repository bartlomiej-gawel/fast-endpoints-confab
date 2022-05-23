using Confab.Shared.Exceptions.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Shared.Exceptions;

internal static class ExceptionExtensions
{
    public static IServiceCollection AddErrorHandling(this IServiceCollection services)
    {
        return services.AddSingleton<ExceptionMiddleware>();
    }

    public static IApplicationBuilder UseErrorHandling(this WebApplication app)
    {
        return app.UseMiddleware<ExceptionMiddleware>();
    }
}