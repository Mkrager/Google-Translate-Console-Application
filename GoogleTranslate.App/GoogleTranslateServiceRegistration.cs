using GoogleTranslate.App.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GoogleTranslate.App
{
    public static class GoogleTranslateServiceRegistration
    {
        public static IServiceCollection AddGoogleTranslateServices(
            this IServiceCollection services)
        {
            //services.AddScoped<IGoogleTranslatorService, GoogleTranslatorService>();
            //services.AddScoped<ITranslationConsoleService, TranslationConsoleService>();

            return services;
        }
    }
}
