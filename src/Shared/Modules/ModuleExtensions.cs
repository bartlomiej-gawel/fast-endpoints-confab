using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Confab.Shared.Modules;

public static class ModuleExtensions
{
    internal static IHostBuilder ConfigureModules(this IHostBuilder builder)
    {
        return builder.ConfigureAppConfiguration((ctx, cfg) =>
        {
            foreach (var settings in GetSettings("*"))
            {
                cfg.AddJsonFile(settings);
            }
            
            foreach (var settings in GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}"))
            {
                cfg.AddJsonFile(settings);
            }
            
            IEnumerable<string> GetSettings(string pattern)
            {
                return Directory.EnumerateFiles(
                    ctx.HostingEnvironment.ContentRootPath,
                    $"module.{pattern}.json",
                    SearchOption.AllDirectories);
            }
        });
    }
}