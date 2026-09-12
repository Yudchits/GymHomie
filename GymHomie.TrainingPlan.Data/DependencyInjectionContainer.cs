using GymHomie.Domain.Core.Constants;
using GymHomie.TrainingPlan.Data.Context;
using GymHomie.TrainingPlan.Data.Repositories;
using GymHomie.TrainingPlan.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymHomie.TrainingPlan.Data
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureTrainingPlanData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TrainingPlanContext>(options =>
            {
                options.UseNpgsql(connectionString: configuration.GetConnectionString("GymHomie"),
                    x => x.MigrationsHistoryTable(tableName: "__ef_migrations_history", 
                        schema: PostgreDbSchemas.Systems)
                );
                options.UseLazyLoadingProxies();
                options.UseSnakeCaseNamingConvention();
            });

            services
                .AddTransient(typeof(IRepository<,>), typeof(Repository<,>))
                .AddTransient<IExerciseRepository, ExerciseRepository>();

            return services;
        }
    }
}
