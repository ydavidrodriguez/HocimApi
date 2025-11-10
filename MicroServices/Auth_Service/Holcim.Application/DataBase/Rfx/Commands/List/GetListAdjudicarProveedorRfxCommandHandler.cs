using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public class GetListAdjudicarProveedorRfxCommandHandler : IGetListAdjudicarProveedorRfxCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;


        public GetListAdjudicarProveedorRfxCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;

        }
        public async Task<object> Execute(Guid IdrFX)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.AdjudicacionProveedor
                .Include(x=> x.Item)
                .Include(x=> x.Proveedor)
                .Where(x => x.RfxId == IdrFX).ToList());
        }
    }
}
