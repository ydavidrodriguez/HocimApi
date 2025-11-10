using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Entities;
using Holcim.Provider.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.List
{
    public class GetListResponseQuestionProviderCommandHandler : IGetListResponseQuestionProviderCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;


        public GetListResponseQuestionProviderCommandHandler(
            IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(Guid ProveedorId, Guid Rfxid)
        {

            Guid proveedor = _dataBaseService.ProveedorUsuario.Where(x => x.UsuarioId == ProveedorId).FirstOrDefault().ProveedorId;

            if(proveedor != null && proveedor != Guid.Empty) 
            {
                List<RespuestaPregunta> respuestaPreguntalist
                 = _dataBaseService.RespuestaPregunta.Where(x => x.ProveedorId == proveedor && x.RfxId == Rfxid).ToList();

                return ResponseApiService.Response(StatusCodes.Status201Created, respuestaPreguntalist);
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, string.Empty);
        }
    }
}
