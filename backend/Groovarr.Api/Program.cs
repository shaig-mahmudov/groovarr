using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Groovarr.Api.Data;
using Microsoft.EntityFrameworkCore;
using Groovarr.Api.Services;
using Groovarr.Api.Services.Jobs;

var builder = WebApplication.CreateBuilder(args);

// figure out environment
var env = builder.Environment;

// ensure data folder exists in dev
string dbPath;
if (env.IsDevelopment())
{
    var dataDir = Path.Combine(AppContext.BaseDirectory, "data");
    Directory.CreateDirectory(dataDir);
    dbPath = Path.Combine(dataDir, "groovarr.db");
}
else
{
    // production convention: /config
    dbPath = "/config/groovarr.db";
}

builder.Services.AddDbContext<GroovarrDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}")
);

string authDbPath;
if (env.IsDevelopment())
{
    var dataDir = Path.Combine(AppContext.BaseDirectory, "data");
    Directory.CreateDirectory(dataDir);
    authDbPath = Path.Combine(dataDir, "auth.db");
}
else
{
    authDbPath = "/config/auth.db";
}

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlite($"Data Source={authDbPath}")
);

void ConfigureDb<TContext>(IServiceCollection services, IConfiguration config, string name)
    where TContext : DbContext
{
    var provider = config[$"DatabaseProvider:{name}"] ?? "sqlite";
    var connStr = config.GetConnectionString(name);

    services.AddDbContext<TContext>(options =>
    {
        switch (provider.ToLower())
        {
            case "postgres":
                options.UseNpgsql(connStr);
                break;
            case "mysql":
                options.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
                break;
            default:
                options.UseSqlite(connStr);
                break;
        }
    });
}

ConfigureDb<GroovarrDbContext>(builder.Services, builder.Configuration, "GroovarrDb");
ConfigureDb<AuthDbContext>(builder.Services, builder.Configuration, "AuthDb");

builder.Services.AddHostedService<CleanupShareLinksJob>();

builder.Services.AddScoped<PlaylistService>();
builder.Services.AddScoped<PlexService>();
builder.Services.AddScoped<SourceFetchService>();
builder.Services.AddScoped<ImportExportService>();
builder.Services.AddScoped<AuditService>();

builder.Services.AddControllers();

// Swagger service registrations
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Groovarr API v1");
    c.RoutePrefix = "docs"; // UI available at /docs
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
