using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace GymHomie.BFF.Web.Extensions
{
    public static class MigrationExtensions
    {
        public static void MigrateDatabase<TContext>(this IApplicationBuilder app)
            where TContext : DbContext
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();

            try
            {
                logger.LogInformation("Start making migrations for {ContextName}...", typeof(TContext).Name);

                var context = services.GetRequiredService<TContext>();
                context.Database.Migrate();

                logger.LogInformation("Migrations for {ContextName} are successfully applied.", typeof(TContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Error making migrations for {ContextName}.", typeof(TContext).Name);
                throw;
            }
        }
    }
}
