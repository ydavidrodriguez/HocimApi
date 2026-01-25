using AutoMapper;
using Holcim.Application.Configuration;
using Holcim.Application.DataBase.Archivo.Commands.List;
using Holcim.Application.DataBase.Cargo.Commands.List;
using Holcim.Application.DataBase.Correo.Commands.Create;
using Holcim.Application.DataBase.Departamento;
using Holcim.Application.DataBase.Estado.Commads.List;
using Holcim.Application.DataBase.Estado.TipoEstado.List;
using Holcim.Application.DataBase.Idioma.Commands.List;
using Holcim.Application.DataBase.Informe.Commands.Create;
using Holcim.Application.DataBase.Informe.Commands.GetById;
using Holcim.Application.DataBase.Informe.Commands.List;
using Holcim.Application.DataBase.Informe.Commands.Update;
using Holcim.Application.DataBase.InformesRol.Create;
using Holcim.Application.DataBase.InformesRol.GetById;
using Holcim.Application.DataBase.InformesRol.List;
using Holcim.Application.DataBase.InformesRol.Update;
using Holcim.Application.DataBase.Invitados.Commands.Create;
using Holcim.Application.DataBase.Item.Commands.Create;
using Holcim.Application.DataBase.Item.Commands.Delete;
using Holcim.Application.DataBase.Item.Commands.List;
using Holcim.Application.DataBase.Item.Commands.Update;
using Holcim.Application.DataBase.Menu.Commands.List;
using Holcim.Application.DataBase.Moneda.Commands.Create;
using Holcim.Application.DataBase.Moneda.Commands.List;
using Holcim.Application.DataBase.Moneda.Commands.Update;
using Holcim.Application.DataBase.Motivo.Commands.List;
using Holcim.Application.DataBase.Pais.Commands.Create;
using Holcim.Application.DataBase.Pais.Commands.List;
using Holcim.Application.DataBase.Pais.Commands.Update;
using Holcim.Application.DataBase.Pregunta.Commands.Create;
using Holcim.Application.DataBase.Pregunta.Commands.Delete;
using Holcim.Application.DataBase.Pregunta.Commands.Update;
using Holcim.Application.DataBase.Proveedor.Commands.Create;
using Holcim.Application.DataBase.Proveedor.Commands.GetById;
using Holcim.Application.DataBase.Proveedor.Commands.List;
using Holcim.Application.DataBase.Proveedor.Commands.Update;
using Holcim.Application.DataBase.Psc.Categorias.List;
using Holcim.Application.DataBase.Psc.Commands.Create;
using Holcim.Application.DataBase.Psc.Commands.GetById;
using Holcim.Application.DataBase.Psc.Commands.List;
using Holcim.Application.DataBase.Psc.Commands.Update;
using Holcim.Application.DataBase.Psc.Grupo.List;
using Holcim.Application.DataBase.Region.Commands.Create;
using Holcim.Application.DataBase.Region.Commands.List;
using Holcim.Application.DataBase.Region.Commands.ListById;
using Holcim.Application.DataBase.Region.Commands.Update;
using Holcim.Application.DataBase.Rfx.Commands.Create;
using Holcim.Application.DataBase.Rfx.Commands.Delete;
using Holcim.Application.DataBase.Rfx.Commands.GettraceabilityRfx;
using Holcim.Application.DataBase.Rfx.Commands.List;
using Holcim.Application.DataBase.Rfx.Commands.PostreassignRfxUser;
using Holcim.Application.DataBase.Rfx.Commands.Update;
using Holcim.Application.DataBase.Rol.Commands.Create;
using Holcim.Application.DataBase.Rol.Commands.List;
using Holcim.Application.DataBase.Rol.Commands.Update;
using Holcim.Application.DataBase.Sobre.Commands.Create;
using Holcim.Application.DataBase.Sobre.Commands.Delete;
using Holcim.Application.DataBase.Sobre.Commands.Update;
using Holcim.Application.DataBase.TipoRfx.Commands.Create;
using Holcim.Application.DataBase.TipoRfx.Commands.List;
using Holcim.Application.DataBase.TrazabilidadRfx.Commands.Create;
using Holcim.Application.DataBase.UnidadMedida.Commands.Create;
using Holcim.Application.DataBase.UnidadMedida.Commands.GetById;
using Holcim.Application.DataBase.UnidadMedida.Commands.List;
using Holcim.Application.DataBase.UnidadMedida.Commands.Update;
using Holcim.Application.DataBase.Usuario.Commands.Create;
using Holcim.Application.DataBase.Usuario.Commands.List;
using Holcim.Application.DataBase.Usuario.Commands.Update;
using Holcim.Application.DataBase.Usuario.Commands.VerifyOtp;
using Holcim.Application.DataBase.ZonaHoraria.Commands.List;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.Application
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

            //Usuario
            services.AddTransient<IUpdateUsuarioCommandHandler, UpdateUsuarioCommandHandler>();
            services.AddTransient<IListUsuarioCommandHandler, ListUsuarioCommandHandler>();
            services.AddTransient<ICreateUsuarioCommandHandler, CreateUsuarioCommandHandler>();
            services.AddTransient<IGetUsuarioToken, GetUsuarioToken>();
            services.AddTransient<IListUsuarioByIdCommandHandler, ListUsuarioByIdCommandHandler>();
            services.AddTransient<IUpdatePasswordUsuarioCommandHandler, UpdatePasswordUsuarioCommandHandler>();
            services.AddTransient<ICreateEmailForgetPasswordByEmail, CreateEmailForgetPasswordByEmail>();
            services.AddTransient<ICreateUsuarioGenericoCommandHandler, CreateUsuarioGenericoCommandHandler>();
            services.AddTransient<IVerifyOtpCommandHandler, VerifyOtpCommandHandler>();


            //Rol
            services.AddTransient<IUpdateRolCommandHandler, UpdateRolCommandHandler>();
            services.AddTransient<IListRolCommandHandler, ListRolCommandHandler>();
            services.AddTransient<ICreateRolCommandHandler, CreateRolCommandHandler>();


            //Menu
            services.AddTransient<IGetUsuarioMenuByEmail, GetUsuarioMenuByEmail>();
            services.AddTransient<IGetMenuByIdCommandHandler, GetMenuByIdCommandHandler>();


            //Cargo
            services.AddTransient<IListCargoCommandHandler, ListCargoCommandHandler>();

            //Pais
            services.AddTransient<IListPaisCommandHandler, ListPaisCommandHandler>();
            services.AddTransient<IListPaisByZonaHorariaByIdCommandHandler, ListPaisByZonaHorariaByIdCommandHandler>();
            services.AddTransient<ICreatePaisCommandHandler, CreatePaisCommandHandler>();
            services.AddTransient<IUpdatePaisCommandHandler, UpdatePaisCommandHandler>();
            services.AddTransient<IListPaisByIdCommandHandler, ListPaisByIdCommandHandler>();
            services.AddTransient<IGetListPaisAllGruCommandHandler, GetListPaisAllGruCommandHandler>();

            //Proveedor
            services.AddTransient<ICreateProveedorCommandHandler, CreateProveedorCommandHandler>();
            services.AddTransient<IGetListProveedorCommandHandler, GetListProveedorCommandHandler>();
            services.AddTransient<IUpdateProveedorCommandHandler, UpdateProveedorCommandHandler>();
            services.AddTransient<IProveedorGetByIdCommandHandler, ProveedorGetByIdCommandHandler>();


            //Idioma
            services.AddTransient<IListIdiomaCommandHandler, ListIdiomaCommandHandler>();
            services.AddTransient<IListIdiomaCommandHandler, ListIdiomaCommandHandler>();

            //Departamento
            services.AddTransient<IListDepartamentoCommandHandler, ListDepartamentoCommandHandler>();

            //Region
            services.AddTransient<ICreateRegionCommandHandler, CreateRegionCommandHandler>();
            services.AddTransient<IGetListRegionCommandHandler, GetListRegionCommandHandler>();
            services.AddTransient<IGetListRegionByIdCommandHandler, GetListRegionByIdCommandHandler>();
            services.AddTransient<IUpdateRegionCommandHandler, UpdateRegionCommandHandler>();


            //Unidad Medida

            services.AddTransient<IListUnidadMedidaCommandHandler, ListUnidadMedidaCommandHandler>();
            services.AddTransient<IUpdateUnidadMedidaCommandHandler, UpdateUnidadMedidaCommandHandler>();
            services.AddTransient<ICreateUnidadMedidaCommandHandler, CreateUnidadMedidaCommandHandler>();
            services.AddTransient<IUnidadMedidaGetByIdCommandHandler, UnidadMedidaGetByIdCommandHandler>();

            //Psc
            services.AddTransient<ICreatePscCommandHandler, CreatePscCommandHandler>();
            services.AddTransient<IGetListPscByIdCommandHandler, GetListPscByIdCommandHandler>();
            services.AddTransient<IGetListPscCommandHandler, GetListPscCommandHandler>();
            services.AddTransient<IUpdatePscCommandHandler, UpdatePscCommandHandler>();
            services.AddTransient<IGetListCategoriaPscCommandHandler, GetListCategoriaPscCommandHandler>();
            services.AddTransient<IGetListGrupoPscCommandHandler, GetListGrupoPscCommandHandler>();

            //Moneda
            services.AddTransient<IListMonedaCommandHandler, ListMonedaCommandHandler>();
            services.AddTransient<ICreateMonedaCommandHandler, CreateMonedaCommandHandler>();
            services.AddTransient<IUpdateMonedaCommandHandler, UpdateMonedaCommandHandler>();
            services.AddTransient<IListMonedaByIdCommandHandler, ListMonedaByIdCommandHandler>();

            //Informes
            services.AddTransient<IListInformesCommandHandler, ListInformesCommandHandler>();
            services.AddTransient<IUpdateInformesCommandHandler, UpdateInformesCommandHandler>();
            services.AddTransient<ICreateInformesCommandHandler, CreateInformesCommandHandler>();
            services.AddTransient<IInformesGetByIdCommandHandler, InformesGetByIdCommandHandler>();

            //InformesRol
            services.AddTransient<ICreateInformesRolCommandHandler, CreateInformesRolCommandHandler>();
            services.AddTransient<IInformesRolGetByIdCommandHandler, InformesRolGetByIdCommandHandler>();
            services.AddTransient<IListInformesRolCommandHandler, ListInformesRolCommandHandler>();
            services.AddTransient<IUpdateInformesRolCommandHandler, UpdateInformesRolCommandHandler>();

            //item
            services.AddTransient<IUpdateItemCommandHandler, UpdateItemCommandHandler>();
            services.AddTransient<IDeleteItemCommandHandler, DeleteItemCommandHandler>();

            //TipoRfx
            services.AddTransient<ICreateTipoRfxCommandHandler, CreateTipoRfxCommandHandler>();
            services.AddTransient<IListTipoRfxCommandHandler, ListTipoRfxCommandHandler>();
            services.AddTransient<IListTipoRfxByIdCommandHandler, ListTipoRfxByIdCommandHandler>();

            //Rfx
            services.AddTransient<ICreateRfxCommandHandler, CreateRfxCommandHandler>();
            services.AddTransient<IListRfxByIdCommandHandler, ListRfxByIdCommandHandler>();
            services.AddTransient<IListRfxCommandHandler, ListRfxCommandHandler>();
            services.AddTransient<IUpdateStateRfxCommandHandler, UpdateStateRfxCommandHandler>();
            services.AddTransient<IPostreassignRfxUserCommandHandler, PostreassignRfxUserCommandHandler>();
            services.AddTransient<IGettraceabilityRfx, GettraceabilityRfx>();
            services.AddTransient<IGetlistRfxStateAprobadoCommadHandler, GetlistRfxStateAprobadoCommadHandler>();
            services.AddTransient<IUpdateRfxCommandHandler, UpdateRfxCommandHandler>();
            services.AddTransient<ICreateRfxTemplateCommandHandler, CreateRfxTemplateCommandHandler>();
            services.AddTransient<IPostCreateAdjudicarRfxCommandHandler, PostCreateAdjudicarRfxCommandHandler>();
            services.AddTransient<ICreateRfxPaisCommandHandler, CreateRfxPaisCommandHandler>();
            services.AddTransient<ICreateItemCommandHandler, CreateItemCommandHandler>();
            services.AddTransient<ICreateSobreCommandHandler, CreateSobreCommandHandler>();
            services.AddTransient<ICreateTrazabilidadCommandHandler, CreateTrazabilidadCommandHandler>();
            services.AddTransient<ICreatePreguntaCommandHandler, CreatePreguntaCommandHandler>();
            services.AddTransient<ICreateInvitadosCommandHandler, CreateInvitadosCommandHandler>();
            services.AddTransient<IGetListRfxByUserCommandHandler, GetListRfxByUserCommandHandler>();
            services.AddTransient<IGetListAdjudicarProveedorRfxCommandHandler, GetListAdjudicarProveedorRfxCommandHandler>();
            services.AddTransient<IPostEditRfxDraftCommandHandler, PostEditRfxDraftCommandHandler>();
            services.AddTransient<IPostDeleteAdjudicarProveedorCommandHandler, PostDeleteAdjudicarProveedorCommandHandler>();
            services.AddTransient<IGetListRfxDraftCommandHandle, GetListRfxDraftCommandHandler>();
            services.AddTransient<IDeleteRfxTemplateCommandHandler, DeleteRfxTemplateCommandHandler>();
            services.AddTransient<IPutUpdatePathRfxCommandHandler, PutUpdatePathRfxCommandHandler>();
            services.AddTransient<ICreateCorreoRfxCommandHandler, CreateCorreoRfxCommandHandler>();
            //Estado
            services.AddTransient<IListEstadoByTypeCommandHandler, ListEstadoByTypeCommandHandler>();
            services.AddTransient<IListEstadoCommandHandler, ListEstadoCommandHandler>();
            services.AddTransient<IListTipoEstadoCommandHandler, ListTipoEstadoCommandHandler>();

            //Archivo
            services.AddTransient<IListArchivosByTypeArchivoCommand, ListArchivosByTypeArchivoCommandHandler>();
            services.AddTransient<IListValoresArchivoCommand, ListValoresArchivoCommandHandler>();

            //Correo
            services.AddTransient<ICreateCorreoCommandHandler, CreateCorreoCommandHandler>();

            //Motivo
            services.AddTransient<IListMotivoCommandHandler, ListMotivoCommandHandler>();


            //zona horario
            services.AddTransient<IGetZonaHorariaCommandHandler, GetZonaHorariaCommandHandler>();

            //Pregunta
            services.AddTransient<IUpdatePreguntaCommandHandler, UpdatePreguntaCommandHandler>();
            services.AddTransient<IUpdatePreguntaCommandHandler, UpdatePreguntaCommandHandler>();
            services.AddTransient<IDeletePreguntaCommandHandler, DeletePreguntaCommandHandler>();


            //Sobre
            services.AddTransient<IDeleteSobreCommandHandler, DeleteSobreCommandHandler>();
            services.AddTransient<IUpdateSobreCommandHandler, UpdateSobreCommandHandler>();


            //Item
            services.AddTransient<IListItemCommandHandler, ListItemCommandHandler>();





            return services;
        }


    }
}
