using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymHomie.TrainingPlan.Application
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureTrainingPlanApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var currentAssembly = typeof(DependencyInjectionContainer).Assembly;

            services.AddAutoMapper(currentAssembly);
            services.AddMediatR(currentAssembly);

            return services;
        }
    }
}
