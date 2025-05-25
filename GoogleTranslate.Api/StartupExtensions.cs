using GoogleTranslate.Api.Middlewares;
using GoogleTranslate.Infrastructure;
using Microsoft.OpenApi.Models;
using GoogleTranslate.Application;

namespace GoogleTranslate.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureService(
            this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices();

            builder.Services.AddControllers();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoogleTranslate API");
            });

            app.MapControllers();

            return app;
        }


        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GoogleTranslate Management API",
                });
            });
        }

    }
}
