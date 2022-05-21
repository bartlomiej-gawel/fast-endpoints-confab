using Confab.Shared;
using Confab.Modules.Conferences;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddShared(builder.Configuration);
builder.Services.AddConferences(builder.Configuration);

var app = builder.Build();
app.UseShared();
app.Run();