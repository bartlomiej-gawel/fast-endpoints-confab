using Confab.Bootstrapper.Modules;
using Confab.Shared;

var builder = WebApplication.CreateBuilder(args);

var assemblies = ModuleLoader.LoadAssemblies();
var modules = ModuleLoader.LoadModules(assemblies);

builder.Services.AddModularInfrastructure();

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