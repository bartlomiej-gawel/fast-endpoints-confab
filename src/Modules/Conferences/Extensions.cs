using System.Runtime.CompilerServices;
using Confab.Modules.Conferences.Infrastructure;
using Confab.Shared.Postgres;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Confab.Bootstrapper")]
namespace Confab.Modules.Conferences;

internal static class Extensions
{
    public static IServiceCollection AddConferences(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres<ConferencesDbContext>(configuration);
        
        return services;
    }
}