using Confab.Modules.Conferences.Infrastructure;
using Confab.Shared.Modules;
using Confab.Shared.Postgres;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Modules.Conferences;

internal class ConferencesModule : IModule
{
    public string Name { get; } = "Conferences";
    
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres<ConferencesDbContext>(configuration);
    }

    public void Use(IApplicationBuilder app)
    {
    }
}