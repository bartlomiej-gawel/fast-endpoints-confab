﻿using System.Runtime.CompilerServices;
using Confab.Shared.Postgres;
using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Confab.Bootstrapper")]
namespace Confab.Shared;

internal static class Extensions
{
    public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        services.AddFastEndpoints();
        return services;
    }

    public static WebApplication UseShared(this WebApplication app)
    {
        app.UseAuthorization();
        app.UseFastEndpoints();
        return app;
    }
}