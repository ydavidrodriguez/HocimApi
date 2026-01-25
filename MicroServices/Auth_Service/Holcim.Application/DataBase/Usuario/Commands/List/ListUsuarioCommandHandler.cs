using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Usuario.Commands.List
{
    public class ListUsuarioCommandHandler : IListUsuarioCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListUsuarioCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public object Execute(string? Nombre, string? Correo)
        {
            var query = _dataBaseService.CuentaAdmin
                .AsNoTracking()
                .Include(x => x.Usuario)
                .Include(x => x.Usuario.TipoUsuario)
                .AsQueryable();

            if (!string.IsNullOrEmpty(Nombre))
            {
                query = query.Where(x => x.Usuario.Nombre.Contains(Nombre));
            }
            else if (!string.IsNullOrEmpty(Correo))
            {
                query = query.Where(x => x.Usuario.Correo.Contains(Correo));
            }
            else
            {
                query = query.Where(x => x.Usuario.TipoUsuario.Nombre == EnumDomain.TipoUsuarioHolcim.GetEnumMemberValue());
            }

            var cuentaAdmins = query.ToList();
            if (!cuentaAdmins.Any())
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, null, "Sin Datos");
            }

            var usuarioIds = cuentaAdmins.Select(x => x.UsuarioId).Distinct().ToList();
            var rolesByUsuario = _dataBaseService.RolUsuario
                .AsNoTracking()
                .Include(y => y.Rol)
                .Where(y => usuarioIds.Contains(y.UsuarioId))
                .GroupBy(y => y.UsuarioId)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Rol).ToList());

            var respuesta = cuentaAdmins.Select(x => new UsuarioFilterResponse
            {
                IdCuentaAdmin = x.IdCuentaAdmin,
                Pais = x.Pais,
                PaisId = x.PaisId,
                UltimaConexion = x.Usuario.UltimaConexion,
                Usuario = _mapper.Map<Domain.Models.Usuario.GetUsuarioResponse>(x.Usuario),
                Rol = rolesByUsuario.TryGetValue(x.UsuarioId, out var roles) ? roles : new List<Domain.Entities.Rol.Rol>()
            }).ToList();

            return ResponseApiService.Response(StatusCodes.Status201Created, respuesta);

        }


    }
}
