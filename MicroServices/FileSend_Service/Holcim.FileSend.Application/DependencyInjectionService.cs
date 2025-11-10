using AutoMapper;
using Holcim.FileSend.Application.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.FileSend.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());

            });
            services.AddSingleton(mapper.CreateMapper());

            return services;
        }
    }
}
