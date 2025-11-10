using Microsoft.OpenApi.Models;

namespace Holcim.AuctionService.Api
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
                    Description = "Administracion de Apis para Holcim Subasta"
                });
            });


            return services;
        }

    }
}
