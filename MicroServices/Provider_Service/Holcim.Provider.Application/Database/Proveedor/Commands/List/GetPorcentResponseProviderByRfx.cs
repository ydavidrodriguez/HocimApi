using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Models.Proveedor;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.List
{
    public class GetPorcentResponseProviderByRfx : IGetPorcentResponseProviderByRfx
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetPorcentResponseProviderByRfx(IMapper mapper, IDapperProcedure dapperProcedure, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService ;
        }
        public object Execute(Guid RfxIdRequest)
        {

            var ParamtersProveedorId = new { RfxId = RfxIdRequest };
            string resultuserprovider = _dapperProcedure.GetQuery(ParamtersProveedorId, "GETRESPONSEPORCENTPROVIDERBYRFX");
            List<GetPorcentResponseProviderByRfxResponse> postListUserProviderResponse = JsonConvert.DeserializeObject<List<GetPorcentResponseProviderByRfxResponse>>(resultuserprovider);
            if(postListUserProviderResponse != null) 
            {
                if (postListUserProviderResponse.Count > 0)
                {
                    return ResponseApiService.Response(StatusCodes.Status201Created, postListUserProviderResponse);

                }
                else { return ResponseApiService.Response(StatusCodes.Status202Accepted,  "Rfx no tiene calificaciones"); }
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, "Rfx no tiene calificaciones");
            }
        }

    }
}
