using Confab.Modules.Conferences;
using Confab.Shared;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddShared();
builder.Services.AddConferences(builder.Configuration);

var app = builder.Build();
app.UseShared();
app.Run();