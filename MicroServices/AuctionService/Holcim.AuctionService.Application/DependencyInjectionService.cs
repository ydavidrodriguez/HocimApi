using AutoMapper;
using Holcim.Application.DataBase.Correo.Commands;
using Holcim.AuctionService.Application.Configuration;
using Holcim.AuctionService.Application.Dapper;
using Holcim.AuctionService.Application.Database.Auction.Commands.GetById;
using Holcim.AuctionService.Application.Database.Auction.Commands.Invite;
using Holcim.AuctionService.Application.Database.Auction.Commands.List;
using Holcim.AuctionService.Application.Database.Ronda.Commands.Get;
using Holcim.AuctionService.Application.Database.Subasta.Command.Actualizar;
using Holcim.AuctionService.Application.Database.Subasta.Command.Create;
using Holcim.AuctionService.Application.Database.Subasta.Command.Delete;
using Holcim.AuctionService.Application.Database.Subasta.Command.List;
using Holcim.AuctionService.Application.Database.Subasta.Command.Update;
using Holcim.AuctionService.Application.Database.TipoSubasta.Commands;
using Holcim.AuctionService.Application.Database.Trazabilidad.Commands;
using Holcim.AuctionService.Application.Database.ZonaHoraria.Commands;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.AuctionService.Application
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
            services.AddScoped<IDapperProcedure, DapperProcedure>();
            services.AddScoped<ICreateSubastaCommandHandler, CreateSubastaCommandHandler>();
            services.AddScoped<ICreateSubastaTemplateCommandHandler, CreateSubastaTemplateCommandHandler>();
            services.AddScoped<ICreateOfferCommandHandler, CreateOfferCommandHandler>();
            services.AddScoped<IUpdateSubastaCommandHandler, UpdateSubastaCommandHandler>();
            services.AddScoped<IUpdateConfiguracionCommandHandler, UpdateConfiguracionCommandHandler>();
            services.AddScoped<IActualizarEstadoSubastaCommandHandler, ActualizarEstadoSubastaCommandHandler>();
            services.AddScoped<IReasignarSubastaCommandHandler, ReasignarSubastaCommandHandler>();
            services.AddScoped<IAgregarTiempoSubastaCommandHandler, AgregarTiempoSubastaCommandHandler>();
            services.AddScoped<IPutUpdateColaboratorsCommandHandler, PutUpdateColaboratorsCommandHandler>();
            services.AddScoped<IEstadoService, EstadoService>();
            //services.AddScoped<ISubastaSchedulerService, SubastaSchedulerService>();
            services.AddScoped<IListAuctionsCommandHandler, ListAuctionsCommandHandler>();
            services.AddScoped<IGetAuctionByIdCommandHandler, GetAuctionByIdCommandHandler>();
            services.AddScoped<IGetOffertByAuctionIdCommandHandler, GetOffertByAuctionIdCommandHandler>();
            services.AddScoped<IInviteProviderCommandHandler, InviteProviderCommandHandler>();
            services.AddScoped<ICreateCorreoCommandHandler, CreateCorreoCommandHandler>();
            services.AddScoped<IGetTipoSubastaCommandHandler, GetTipoSubastaCommandHandler>();
            services.AddScoped<IGetLogsSubastaCommandHandler, GetLogsSubastaCommandHandler>();
            services.AddScoped<IGetZonaHorariaCommandHandler, GetZonaHorariaCommandHandler>();
            services.AddScoped<IGetAuctionByProviderIdCommandHandler, GetAuctionByProviderIdCommandHandler>();
            services.AddScoped<ICreateAdjudicarSubastaCommandHandler, CreateAdjudicarSubastaCommandHandle>();
            services.AddScoped<IDeleteAdjudicarSubastaCommandHandle, DeleteAdjudicarSubastaCommandHandle>();
            services.AddScoped<IIistBySubastaIdCommandHandler, IistBySubastaIdCommandHandler>();
            services.AddScoped<IUpdateFechaPausaSubastaCommandHandler, UpdateFechaPausaSubastaCommandHandler>();
            services.AddScoped<IUpdateReanudarSubastaCommandHandler, UpdateReanudarSubastaCommandHandler>();
            services.AddScoped<IGetLastRoundItemsCommandHandler, GetLastRoundItemsCommandHandler>();
            services.AddScoped<IDeleteOfertaSubastaCommandHandler, DeleteOfertaSubastaCommandHandler>();
            services.AddScoped<ICreateListAdjudicarSubastaCommandHandler, CreateListAdjudicarSubastaCommandHandle>();

            services.AddScoped<IPutSubastaUpdatePathCommandHandler, PutSubastaUpdatePathCommandHandler>();
            return services;

        }

    }
}
