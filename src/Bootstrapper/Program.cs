using Confab.Shared;
using Confab.Shared.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureModules();

var assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
var modules = ModuleLoader.LoadModules(assemblies);

builder.Services.AddModularInfrastructure(builder.Configuration, assemblies, modules);

foreach (var module in modules)
{
    module.Register(builder.Services, builder.Configuration);
}

var app = builder.Build();

app.UseModularInfrastructure();

foreach (var module in modules)
{
    module.Use(app);
}

assemblies.Clear();
modules.Clear();

app.Run();