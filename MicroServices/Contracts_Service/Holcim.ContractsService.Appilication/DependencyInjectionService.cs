using AutoMapper;
using Holcim.ContractsService.Appilication.Configuration;
using Holcim.ContractsService.Appilication.Database.Contratos.Command.Create;
using Holcim.ContractsService.Appilication.Database.Contratos.Command.GetById;
using Holcim.ContractsService.Appilication.Database.Contratos.Command.List;
using Holcim.ContractsService.Appilication.Database.Contratos.Command.Update;
using Holcim.ContractsService.Appilication.Database.Contratos.TipoContrato.Commands.List;
using Holcim.ContractsService.Appilication.Database.FlujoAprobacion.Command.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.ContractsService.Appilication
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

            //Contrato
            services.AddTransient<ICreateContratoCommandHandler, CreateContratoCommandHandler>();
            services.AddTransient<IGetContratoByIdCommandHandler, GetContratoByIdCommandHandler>();
            services.AddTransient<IGetListContratoCommandHandler, GetListContratoCommandHandler>();
            services.AddTransient<IUpdateContratoCommandHandler, UpdateContratoCommandHandler>();
            services.AddTransient<ICreateFlujoAprobacionCommandHandler, CreateFlujoAprobacionCommandHandler>();
            services.AddTransient<IGetListTipoContratoCommandHandler, GetListTipoContratoCommandHandler>();
            services.AddTransient<IUpdateContratoCommandHandler, UpdateContratoCommandHandler>();
            services.AddTransient<IUpdateStateContratoCommandHandler, UpdateStateContratoCommandHandler>();


            return services;
        }


    }
}
