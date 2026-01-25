using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Application.Helpers;
using Holcim.Domain.Entities.Rol;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Usuario.Commands.Create
{
    public class CreateUsuarioGenericoCommandHandler : ICreateUsuarioGenericoCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateUsuarioGenericoCommandHandler(IDataBaseService dataBaseService,  IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<object> Execute(Domain.Entities.Usuario.Usuario usuario,
            List<Guid>? ListRolid, Guid TipoUsuario)
        {
            var lang = _httpContextAccessor.HttpContext?.Items["lang"] as string ?? "es";
            var idioma = _dataBaseService.Idioma.Where(a => a.Key == lang).FirstOrDefault();
            var Entitymapper = _mapper.Map<Domain.Entities.Usuario.Usuario>(usuario);
            Entitymapper.IdUsuario = Guid.NewGuid();
            Entitymapper.Estado = true;
            var plainPassword = HelperCorreo.CreatePassword(10);
            Entitymapper.Contrasena = HelperPassword.Hash(plainPassword);
            Entitymapper.FechaCreacion = DateTime.Now;
            Entitymapper.FechaActulizacion = DateTime.Now;
            Entitymapper.PrimerIngreso = true;
            Entitymapper.TipoUsuarioId = TipoUsuario;
            Entitymapper.IdiomaId = idioma.IdIdioma;
            _dataBaseService.Usuario.Add(Entitymapper);

            foreach (var item in ListRolid)
            {
                RolUsuario rolUsuario = new RolUsuario();

                rolUsuario.IdRolUsuario = Guid.NewGuid();
                rolUsuario.UsuarioId = Entitymapper.IdUsuario;
                rolUsuario.RolId = item;

                _dataBaseService.RolUsuario.Add(rolUsuario);

            }

            var response = new UsuarioCreatedResponse
            {
                IdUsuario = Entitymapper.IdUsuario,
                Contrasena = plainPassword
            };

            return ResponseApiService.Response(StatusCodes.Status201Created, response);

        }

    }
}
