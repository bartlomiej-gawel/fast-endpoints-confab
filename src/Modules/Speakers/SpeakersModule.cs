using Confab.Shared.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Modules.Speakers;

internal class SpeakersModule : IModule
{
    public string Name { get; } = "Speakers";
    
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    public void Use(IApplicationBuilder app)
    {
        throw new NotImplementedException();
    }
}