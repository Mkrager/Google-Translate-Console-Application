using GoogleTranslate.Application.Contracts.Infrastructure;
using GoogleTranslate.Infrastructure.GoogleTranslate;
using Microsoft.Extensions.DependencyInjection;

namespace GoogleTranslate.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddTransient<IGoogleTranslateService, GoogleTranslateService>();

            return services;
        }

    }
}
