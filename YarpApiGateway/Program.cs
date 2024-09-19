using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Yarp.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

// Add YARP reverse proxy services and load configuration from appsettings.json
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Optional: Add logging for diagnostics (if needed)
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
});

var app = builder.Build();

// Map the reverse proxy routes
app.MapReverseProxy();

app.Run();
