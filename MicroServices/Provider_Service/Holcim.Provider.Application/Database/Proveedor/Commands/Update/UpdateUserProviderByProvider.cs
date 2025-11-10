using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Entities;
using Holcim.Provider.Domain.Models;
using Holcim.Provider.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.Update
{
    public class UpdateUserProviderByProvider : IUpdateUserProviderByProvider
    {
        
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public UpdateUserProviderByProvider(IMapper mapper, IDapperProcedure dapperProcedure)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            
        }
        public async Task<object> Execute(PutUsuarioUpdateRequest putUsuarioUpdateRequest)
        {
            var ParametersRespuestaUsuario = new { IdProveedor = putUsuarioUpdateRequest.IdProveedor, 
                Nombre = putUsuarioUpdateRequest.Nombre, Apellido = putUsuarioUpdateRequest.Apellido, 
                Estado = putUsuarioUpdateRequest.Estado, IdUsuario = putUsuarioUpdateRequest.IdUsuario};

            var response = _dapperProcedure.UpdateQuery(ParametersRespuestaUsuario, "PUTUPDATEUSERPROVIDER");

            return ResponseApiService.Response(StatusCodes.Status201Created, putUsuarioUpdateRequest);

        }

    }
}
