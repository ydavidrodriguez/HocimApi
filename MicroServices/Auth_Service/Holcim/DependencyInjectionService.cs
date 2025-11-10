using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Holcim
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Holcim Api",
                    Description = "Administracion de Apis para Holcim"
                });

                options.AddSecurityDefinition("", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey

                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();

            });



            return services;
        }

    }
}
