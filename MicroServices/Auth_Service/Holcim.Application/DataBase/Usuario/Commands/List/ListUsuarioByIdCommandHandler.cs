using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Usuario.Commands.List
{
    public class ListUsuarioByIdCommandHandler : IListUsuarioByIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListUsuarioByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public object Execute(Guid idUser)
        {
            UsuarioFilterResponse cuentaAdmin = _dataBaseService.CuentaAdmin.
             Include(x => x.Usuario)
             .Include(x => x.Usuario.TipoUsuario)
                    .Where(x => x.Usuario.IdUsuario == idUser)
                    .Select(x =>
                     new UsuarioFilterResponse
                     {
                         IdCuentaAdmin = x.IdCuentaAdmin,
                         Pais = x.Pais,
                         PaisId = x.PaisId,
                         Usuario = _mapper.Map<Domain.Models.Usuario.GetUsuarioResponse>(x.Usuario),
                         UltimaConexion = x.Usuario.UltimaConexion,
                         Rol = _dataBaseService.RolUsuario.Include(y => y.Rol).Where(y => y.UsuarioId == x.UsuarioId)
                         .Select(y => y.Rol).ToList(),
                     }
                ).First();


            return ResponseApiService.Response(StatusCodes.Status201Created,
               cuentaAdmin);
        }

    }
}
