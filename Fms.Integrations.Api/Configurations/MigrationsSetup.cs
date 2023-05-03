using System.Threading.Tasks;
using Fms.Application.Core.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fms.Integrations.Api.Configurations;

public static class MigrationsSetup
{
    public static async Task Migrate(this WebApplication app, bool ensureRather=true)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<IAssemblyMarker>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<IContext>();

        logger.LogInformation("Running migrations...");
        if (ensureRather)
            await dbContext.Database.EnsureCreatedAsync();
        else
            await dbContext.Database.MigrateAsync();
        logger.LogInformation("Migrations applied succesfully");
    }
}