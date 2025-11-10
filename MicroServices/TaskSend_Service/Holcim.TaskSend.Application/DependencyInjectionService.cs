using AutoMapper;
using Holcim.TaskSend.Application.Configuration;
using Holcim.TaskSend.Application.DataBase.Correo;
using Holcim.TaskSend.Application.DataBase.Email.Commands.Create;
using Holcim.TaskSend.Application.DataBase.Email.Commands.SendEmail;
using Holcim.TaskSend.Application.External.Smtp;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.TaskSend.Application
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

            //Email

            services.AddTransient<ICreateCorreoCommandHandler, CreateCorreoCommandHandler>();



            return services;
        }

    }
}
