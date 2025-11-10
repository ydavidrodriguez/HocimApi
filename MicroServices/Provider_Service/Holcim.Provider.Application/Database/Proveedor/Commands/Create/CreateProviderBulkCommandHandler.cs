using AutoMapper;
using Dapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Models;
using Holcim.Provider.Domain.Models.Proveedor;
using Holcim.Provider.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.Create
{
    public class CreateProviderBulkCommandHandler : ICreateProviderBulkCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;
        private readonly ICreateUserProviderByProviderCommandHandler _createUserProviderByProviderCommandHandler;

        public CreateProviderBulkCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure,
            IDataBaseService dataBaseService, ICreateUserProviderByProviderCommandHandler createUserProviderByProviderCommandHandler)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
            _createUserProviderByProviderCommandHandler = createUserProviderByProviderCommandHandler;
        }

        public object Execute(List<CreateUserBulkRequest> createUserBulkRequest)
        {


            List<GetUsuarioCreationResponse> usuarioCreationResponses = new List<GetUsuarioCreationResponse>();

            foreach (var userRequest in createUserBulkRequest)
            {
                // Crear proveedor
                Guid proveedorId = CrearProveedor(userRequest);
                if (proveedorId == Guid.Empty)
                {
                    return ResponseApiService.Response(StatusCodes.Status202Accepted, "Error al crear proveedor");
                }

                // Crear usuario principal
                var usuarioPrincipalResponse = CrearUsuarioProvider(
                    userRequest.Nombre,
                    userRequest.Correo,
                    userRequest.Apellido,
                    proveedorId,
                    userRequest.NombreEmpresa
                );
                usuarioCreationResponses.Add(usuarioPrincipalResponse);

                // Crear usuarios adicionales
                foreach (var usuario in userRequest.Usuarios)
                {
                    var usuarioResponse = CrearUsuarioProvider(
                        usuario.Nombre,
                        usuario.Correo,
                        usuario.Apellido,
                        proveedorId,
                        userRequest.NombreEmpresa
                    );
                    usuarioCreationResponses.Add(usuarioResponse);
                }
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, usuarioCreationResponses);
        }

        // Método para crear un proveedor y devolver su ID
        Guid CrearProveedor(CreateUserBulkRequest userRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NombreEmpresa", userRequest.NombreEmpresa);
            parameters.Add("@RegistroMercantil", userRequest.RegistroMercantil);
            parameters.Add("@PaisId", userRequest.PaisId);
            parameters.Add("@Telefono", userRequest.Telefono);
            parameters.Add("@Correo", userRequest.Correo);
            parameters.Add("@ZonaHorariaId", userRequest.ZonaHorariaId);
            parameters.Add("@IdProveedor", dbType: System.Data.DbType.Guid, direction: System.Data.ParameterDirection.Output);

            string idProveedorOutput = _dapperProcedure.OutputQuery(parameters, "POSTCREATERPROVEEDOR", "@IdProveedor");
            return JsonConvert.DeserializeObject<Guid>(idProveedorOutput);
        }

        // Método para crear un usuario proveedor
        GetUsuarioCreationResponse CrearUsuarioProvider(string nombre, string correo, string apellido, Guid proveedorId, string nombreEmpresa)
        {
            var userProviderRequest = new CreateUserProviderRequest
            {
                Nombre = nombre,
                Correo = correo,
                Apellido = apellido,
                ProveedorId = proveedorId
            };

            var baseResponse = (BaseResponseModel)_createUserProviderByProviderCommandHandler.Execute(userProviderRequest);
            bool isSuccessful = baseResponse.StatusCode == StatusCodes.Status201Created;

            return getUsuarioCreationResponse(correo,apellido, nombre, nombreEmpresa, baseResponse.Data, isSuccessful);
        }

        public GetUsuarioCreationResponse getUsuarioCreationResponse(string correo, string apellido, string nombre, string nombreempresa, string mensaje, bool realizado)
        {
            GetUsuarioCreationResponse getUsuarioCreationResponses = new GetUsuarioCreationResponse();

            getUsuarioCreationResponses.Correo = correo;
            getUsuarioCreationResponses.Nombre = nombre + "" + apellido;
            getUsuarioCreationResponses.NombreEmpresa = nombreempresa;
            getUsuarioCreationResponses.Mensaje = mensaje.ToString();
            getUsuarioCreationResponses.Realizado = realizado;

            return getUsuarioCreationResponses;

        }

    }
}
