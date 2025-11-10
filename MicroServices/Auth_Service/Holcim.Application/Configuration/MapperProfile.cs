using AutoMapper;
using Holcim.Domain.Entities.Moneda;
using Holcim.Domain.Entities.Pais;
using Holcim.Domain.Entities.PreguntaArchivo;
using Holcim.Domain.Entities.Proveedor;
using Holcim.Domain.Entities.Pscs;
using Holcim.Domain.Entities.Region;
using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Entities.Rol;
using Holcim.Domain.Entities.TipoRfx;
using Holcim.Domain.Entities.UnidadMedida;
using Holcim.Domain.Entities.Usuario;
using Holcim.Domain.Models.Item;
using Holcim.Domain.Models.Moneda;
using Holcim.Domain.Models.Pais;
using Holcim.Domain.Models.Pregunta;
using Holcim.Domain.Models.Proveedor;
using Holcim.Domain.Models.Psc;
using Holcim.Domain.Models.Region;
using Holcim.Domain.Models.Rfx;
using Holcim.Domain.Models.Rol;
using Holcim.Domain.Models.UnidadMedida;
using Holcim.Domain.Models.Usuario;

namespace Holcim.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Usuario
            CreateMap<Usuario,UpdateUsuarioRequest>().ReverseMap();
            CreateMap<Usuario,CreateUsuarioRequest>().ReverseMap();
            CreateMap<GetUsuarioResponse, Usuario>().ReverseMap();

            //Rol
            CreateMap<Rol, CreateRolRequest>().ReverseMap();
            CreateMap<Rol, UpdateRolRequest>().ReverseMap();

            //Proveedor
            CreateMap<Proveedor, CreatProveedorRequest>().ReverseMap();


            //Region
            CreateMap<Region, CreateRegionRequest>().ReverseMap();
            CreateMap<Region, UpdateRegionRequest>().ReverseMap();

            //Medida
            CreateMap<UnidadMedida, UpdateUnidadMedidaRequest>().ReverseMap();
            CreateMap<UnidadMedida, CreateUnidadMedidaRequest>().ReverseMap();

            //PSC
            CreateMap<Pscs, CreatePscRequest>().ReverseMap();
            CreateMap<Pscs, UpdatePscRequest>().ReverseMap();

            //Pais
            CreateMap<Pais, CreatePaisRequest>().ReverseMap();

            //Moneda
            CreateMap<Moneda, CreateMonedaRequest>().ReverseMap();

            //Rfx
            CreateMap<Rfx, CreateRfxRequest>().ReverseMap();
            CreateMap<RfxTemporal, UpdateRfxRequestDraft>().ReverseMap();

            //TipoRfx
            CreateMap<TipoRfx, CreateTipoRfxRequest>().ReverseMap();

            //proveedor
            CreateMap<Proveedor, UpdateProveedorRequest>().ReverseMap();

            CreateMap<PreguntaArchivo, CrearPregunta>().ReverseMap();

            CreateMap<UpdateItemRequest, CreateItemRequest>().ReverseMap();

            CreateMap<UpdateArchivoSobre, ArchivoSobre>().ReverseMap();


        }
    }
}
