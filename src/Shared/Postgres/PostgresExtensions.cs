using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Shared.Postgres;

public static class PostgresExtensions
{
    internal static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        return services.Configure<PostgresOptions>(configuration.GetSection("Postgres"));
    }

    public static IServiceCollection AddPostgres<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
    {
        var connectionString = configuration[$"Postgres:{nameof(PostgresOptions.ConnectionString)}"];

        return services.AddDbContext<T>(x => x.UseNpgsql(connectionString));
    }
}