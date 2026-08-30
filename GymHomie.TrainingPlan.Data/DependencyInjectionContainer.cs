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
                options.UseSqlServer(configuration.GetConnectionString("TrainingPlan"));
                options.UseLazyLoadingProxies();
            });

            services
                .AddTransient(typeof(IRepository<,>), typeof(Repository<,>))
                .AddTransient<IExerciseRepository, ExerciseRepository>();

            return services;
        }
    }
}
