using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Entities;
using Holcim.Provider.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.Create
{
    public class PostResponseCreateQuestionProvider : IPostResponseCreateQuestionProvider
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public PostResponseCreateQuestionProvider(IMapper mapper, IDapperProcedure dapperProcedure, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(List<RespuestaPreguntaRequest> respuestaPregunta)
        {
            var ParametersRespuestaUsuario = new { UsuarioId = respuestaPregunta[0].ProveedorId };

            var idproveedor = _dapperProcedure.GetQuery(ParametersRespuestaUsuario, "GETPROVEEDORBYUSER");
            if (idproveedor != null)
            {
                List<IdProveedorResponse> idproveedorresponse = JsonConvert.DeserializeObject<List<IdProveedorResponse>>(idproveedor);

                foreach (var respuestaitem in respuestaPregunta)
                {

                    var entitymapper = _mapper.Map<RespuestaPregunta>(respuestaitem);
                    entitymapper.IdRespuestaPregunta = Guid.NewGuid();
                    entitymapper.ProveedorId = idproveedorresponse[0].IdProveedor;
                    entitymapper.FechaCreacion = DateTime.Now;


                    _dataBaseService.RespuestaPregunta.Add(entitymapper);

                }

                var ParametersRespuestaProveedor = new { RfxId = respuestaPregunta[0].RfxId, ProveedorId = idproveedorresponse[0].IdProveedor };

                var response = _dapperProcedure.UpdateQuery(ParametersRespuestaProveedor, "POSTUPDATEPROVEEDORRFX");

                await _dataBaseService.SaveAsync();

            }


            return ResponseApiService.Response(StatusCodes.Status201Created, respuestaPregunta);

        }

    }
}
