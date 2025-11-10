using AutoMapper;
using Holcim.Application.DataBase.Correo.Commands.Create;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.CuentaAdmin;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Models;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Usuario.Commands.Create
{
    internal class CreateUsuarioCommandHandler : ICreateUsuarioCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly ICreateCorreoCommandHandler _createCorreoCommandHandler;
        private readonly ICreateUsuarioGenericoCommandHandler _createUsuarioGenericoCommandHandler;

        public CreateUsuarioCommandHandler(IDataBaseService dataBaseService, IMapper mapper,
            ICreateCorreoCommandHandler createCorreoCommandHandler, ICreateUsuarioGenericoCommandHandler createUsuarioGenericoCommandHandler)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _mapper = mapper;
            _createCorreoCommandHandler = createCorreoCommandHandler;
            _createUsuarioGenericoCommandHandler = createUsuarioGenericoCommandHandler;
        }

        public async Task<object> Execute(CreateUsuarioRequest createUsuarioRequest)
        {
            if (_dataBaseService.Usuario.Where(x => x.Correo == createUsuarioRequest.Correo).FirstOrDefault() == null)
            {

                var Entitymapper = _mapper.Map<Domain.Entities.Usuario.Usuario>(createUsuarioRequest);
                BaseResponseModel baseResponseModelEntityUser = (BaseResponseModel)await _createUsuarioGenericoCommandHandler.Execute(Entitymapper, createUsuarioRequest.RolId, _dataBaseService.TipoUsuario.Where(x => x.Nombre == EnumDomain.TipoUsuarioHolcim.GetEnumMemberValue().ToString().Trim()).First().IdTipoUsuario);

                CuentaAdmin cuentaAdmin = new CuentaAdmin();

                cuentaAdmin.IdCuentaAdmin = Guid.NewGuid();
                cuentaAdmin.PaisId = createUsuarioRequest.PaisId;
                cuentaAdmin.UsuarioId = baseResponseModelEntityUser.Data.IdUsuario;
                cuentaAdmin.Estado = true;
                cuentaAdmin.FechaActulizacion = DateTime.Now;
                cuentaAdmin.FechaActulizacion = DateTime.Now;
                _dataBaseService.CuentaAdmin.Add(cuentaAdmin);

                // Prepare the replacement values
                var replacements = new Dictionary<string, string>
                {
                    { "{0}", createUsuarioRequest.Nombre },
                    { "{1}", createUsuarioRequest.Correo },
                    { "{2}", baseResponseModelEntityUser.Data.Contrasena}
                };

                await _createCorreoCommandHandler.Execute(new List<string> { createUsuarioRequest.Correo }, "Creacion Usuario Holcim",
                    EnumDomain.CreacionUsuarioHolcim.GetEnumMemberValue().ToString().Trim(),
                    replacements);

                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, createUsuarioRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Usuario Ya Registrado");

            }


        }

    }
}
