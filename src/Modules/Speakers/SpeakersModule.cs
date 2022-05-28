using Confab.Modules.Speakers.Infrastructure;
using Confab.Shared.Modules;
using Confab.Shared.Postgres;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Modules.Speakers;

internal class SpeakersModule : IModule
{
    public string Name { get; } = "Speakers";
    
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres<SpeakersDbContext>(configuration);
    }

    public void Use(IApplicationBuilder app)
    {
    }
}