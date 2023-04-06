using CoinApi.Services.Exercise;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace CoinApi.Extensions
{
    public static class CoinApiExtension
    {
        public static IServiceCollection AddServiceConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IExerciseService, ExerciseService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
