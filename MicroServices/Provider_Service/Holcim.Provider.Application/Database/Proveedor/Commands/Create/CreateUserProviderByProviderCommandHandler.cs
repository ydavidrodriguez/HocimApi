using AutoMapper;
using Dapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Application.Helpers;
using Holcim.Provider.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.Create
{
    public class CreateUserProviderByProviderCommandHandler : ICreateUserProviderByProviderCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public CreateUserProviderByProviderCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
        }
        public object Execute(CreateUserProviderRequest createUserProviderRequest)
        {

            var parametrsItem = new DynamicParameters();
            parametrsItem.Add("@Nombre", createUserProviderRequest.Nombre);
            parametrsItem.Add("@Apellido", createUserProviderRequest.Apellido);
            parametrsItem.Add("@Correo", createUserProviderRequest.Correo);
            parametrsItem.Add("@Contrasena", HelperCorreo.CreatePassword(10));
            parametrsItem.Add("@IdUsuario", dbType: System.Data.DbType.Guid, direction: System.Data.ParameterDirection.Output);

            var ResultUser = _dapperProcedure.OutputQuery(parametrsItem, "POSTCREATEUSERPROVEEDOR", "@IdUsuario");
            Guid Idusuario = JsonConvert.DeserializeObject<Guid>(ResultUser);

            if (Idusuario != null)
            {
                if (Idusuario != Guid.Empty)
                {
                    if (_dataBaseService.ProveedorUsuario.Where(x => x.ProveedorId == createUserProviderRequest.ProveedorId && x.UsuarioId == Idusuario).FirstOrDefault() == null)
                    {
                        var Enitymapper = _mapper.Map<Domain.Entities.ProveedorUsuario>(createUserProviderRequest);
                        Enitymapper.IdProveedorUsuario = Guid.NewGuid();
                        Enitymapper.Estado = true;
                        Enitymapper.UsuarioId = Idusuario;
                        Enitymapper.ProveedorId = createUserProviderRequest.ProveedorId;
                        _dataBaseService.ProveedorUsuario.Add(Enitymapper);
                        _dataBaseService.SaveAsync();
                    }
                    else
                    {
                        return ResponseApiService.Response(StatusCodes.Status202Accepted, "Usuario Ya Registrado con ese proveedor", "Usuario Ya Registrado con ese proveedor");
                    }

                }
                else { return ResponseApiService.Response(StatusCodes.Status202Accepted, "Usuario Ya Existente con ese correo", "Usuario Ya Existente con ese correo"); }


            }

            return ResponseApiService.Response(StatusCodes.Status201Created, createUserProviderRequest);

        }

    }
}
