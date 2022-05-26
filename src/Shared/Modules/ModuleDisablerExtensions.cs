using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Shared.Modules;

public static class ModuleDisablerExtensions
{
    internal static IMvcBuilder AddModuleDisabler(this IServiceCollection services, IConfiguration configuration)
    {
        var disabledModules = new List<string>();

        foreach (var (key, value) in configuration.AsEnumerable())
        {
            if (!key.Contains(":Module:Enabled"))
            {
                continue;
            }

            if (!bool.Parse(value))
            {
                disabledModules.Add(key.Split(":")[0]);
            }
        }

        return services.AddControllers().ConfigureApplicationPartManager(manager =>
        {
            var removedParts = new List<ApplicationPart>();

            foreach (var disabledModule in disabledModules)
            {
                var parts = manager.ApplicationParts
                    .Where(x => x.Name.Contains(disabledModule));

                removedParts.AddRange(parts);
            }

            foreach (var part in removedParts)
            {
                manager.ApplicationParts.Remove(part);
            }
        });
    }
}