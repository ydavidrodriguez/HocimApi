using AutoMapper;

namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public class GetlistRfxStateAprobadoCommadHandler : IGetlistRfxStateAprobadoCommadHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetlistRfxStateAprobadoCommadHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid IdUsuario)
        {

            //Domain.Entities.Usuario.Usuario usuario = _dataBaseService.Usuario.Include(x=> x.Rol)
            //     .Where(u => u.IdUsuario == IdUsuario).First();

            List<Domain.Entities.Rfx.Rfx> Listrfx = new List<Domain.Entities.Rfx.Rfx>();

            //if (usuario.Rol.Nombre == EnumDomain.AdministradorSistema.GetEnumMemberValue().ToString()) 
            //{
            //    Listrfx = _dataBaseService.Rfx.ToList();

            //}
            //else if (usuario.Rol.Nombre == EnumDomain.AdministradorRegional.GetEnumMemberValue().ToString())
            //{
            //    Domain.Entities.CuentaAdmin.CuentaAdmin cuentaAdmin = _dataBaseService.CuentaAdmin
            //        .Include(x=> x.Pais)
            //        .Include(x=> x.Pais.Region)
            //        .Where(u => u.UsuarioId == usuario.IdUsuario).First();

            //    Listrfx =  _dataBaseService.Rfx.Where(x => x.RegionId == cuentaAdmin.Pais.RegionId).ToList();
            //}
            //else 
            //{
            //    Listrfx = _dataBaseService.Rfx.Where(x => x.UsuarioCreacion == usuario.IdUsuario).ToList();
            //}

            return Listrfx;

        }

    }
}
