using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Usuario.Commands.List
{
    public class GetUsuarioMenuByEmail : IGetUsuarioMenuByEmail
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUsuarioMenuByEmail(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid Idusuario)
        {
            List<GetUsuarioMenuByEmailRequest> ListgetUsuarioMenuByEmailRequest = new List<GetUsuarioMenuByEmailRequest>();
            Domain.Entities.Usuario.Usuario usuario = _dataBaseService.Usuario.Where(x => x.IdUsuario == Idusuario).FirstOrDefault();

            if (usuario != null)
            {
                List<Guid> rolUsuario = _dataBaseService.RolUsuario.Where(x => x.UsuarioId == Idusuario).Select(x => x.RolId).ToList();

                var menuusuario = _dataBaseService.RolMenu
                    .Include(x => x.Rol)
                    .Include(x => x.Menu)
                    .Where(x => rolUsuario.Contains(x.RolId)).ToList();


                foreach (var itemmenu in menuusuario.Where(x => x.Menu.IdPadre == null && x.Menu.FormularioInterno == null).ToList())
                {
                    if (ListgetUsuarioMenuByEmailRequest.Where(x => x.Menu.Nombre == itemmenu.Menu.Nombre).FirstOrDefault() == null)
                    {

                        GetUsuarioMenuByEmailRequest getUsuarioMenuByEmailRequest = new GetUsuarioMenuByEmailRequest();

                        getUsuarioMenuByEmailRequest.IdMenuRol = itemmenu.RolMenuId;
                        getUsuarioMenuByEmailRequest.NombreUsuario = usuario.Nombre + " " + usuario.Apellido;
                        getUsuarioMenuByEmailRequest.IdUsuario = usuario.IdUsuario;
                        getUsuarioMenuByEmailRequest.RolId = itemmenu.RolId;
                        getUsuarioMenuByEmailRequest.MenuId = itemmenu.MenuId;
                        getUsuarioMenuByEmailRequest.Menu = itemmenu.Menu;
                        getUsuarioMenuByEmailRequest.Posicion = itemmenu.Menu.Posicion;
                        getUsuarioMenuByEmailRequest.Rol = itemmenu.Rol;
                        getUsuarioMenuByEmailRequest.PrimerIngreso = usuario.PrimerIngreso;
                        getUsuarioMenuByEmailRequest.Hijos = menuusuario.Where(x => x.Menu.IdPadre == itemmenu.Menu.IdMenu && x.Menu.FormularioInterno == null).
                            Select(x => new Domain.Models.Menu.MenuHIjoAccionesResponse
                            {

                                IdMenu = x.MenuId,
                                Estado = x.Menu.Estado,
                                IdPadre = x.Menu.IdPadre,
                                Nombre = x.Menu.Nombre,
                                PathFront = x.Menu.PathFront,
                                ListAcciones = _dataBaseService.AccionesMenu.Where(y => y.RolId == x.RolId && y.MenuId == x.MenuId)
                                      .Select(a => a.Acciones).ToList()

                            }).ToList();

                        ListgetUsuarioMenuByEmailRequest.Add(getUsuarioMenuByEmailRequest);
                    }

                }
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, ListgetUsuarioMenuByEmailRequest); ;
        }

    }
}
