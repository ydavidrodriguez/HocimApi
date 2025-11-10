using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.List
{
    public class GetListUserProviderCommandHandler : IGetListUserProviderCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetListUserProviderCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
        }

        public object Execute(Guid ProveedorId)
        {
            var ParamtersProveedorId = new { IdProveedor = ProveedorId };
            string resultuserprovider = _dapperProcedure.GetQuery(ParamtersProveedorId, "GETLISTUSERPROVIDER");
            List<PostListUserProviderResponse> postListUserProviderResponse = JsonConvert.DeserializeObject<List<PostListUserProviderResponse>>(resultuserprovider);

            return ResponseApiService.Response(StatusCodes.Status201Created, postListUserProviderResponse);

        }

    }
}
