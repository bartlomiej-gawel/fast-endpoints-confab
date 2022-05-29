using Confab.Modules.Users.Infrastructure;
using Confab.Shared.Modules;
using Confab.Shared.Postgres;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Modules.Users;

internal class UsersModule : IModule
{
    public string Name { get; } = "Users";
    
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres<UsersDbContext>(configuration);
    }

    public void Use(IApplicationBuilder app)
    {
    }
}