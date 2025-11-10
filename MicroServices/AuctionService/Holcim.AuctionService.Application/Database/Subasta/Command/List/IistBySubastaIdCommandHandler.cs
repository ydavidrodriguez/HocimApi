using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models;
using Holcim.AuctionService.Domain.Models.Item;
using Holcim.AuctionService.Domain.Models.Proveedor;
using Holcim.AuctionService.Domain.Models.Subasta;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.List
{
    public class IistBySubastaIdCommandHandler : IIistBySubastaIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public IistBySubastaIdCommandHandler(
            IDataBaseService dataBaseService,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor
         )
        {
            _dataBaseService = dataBaseService;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<object> Execute(Guid SubastaId)
        {
            List<Domain.Entities.GanadorSubasta.GanadorSubasta> ganadorSubastaList =
                 _dataBaseService.GanadorSubasta.Where(x => x.SubastaId == SubastaId).ToList();
            List<GetGanadorSubastaResponse> listganadores = new List<GetGanadorSubastaResponse>();

            foreach (var ganadorsbasta in ganadorSubastaList)
            {
                GetGanadorSubastaResponse newganadoressubasta = new GetGanadorSubastaResponse();

                newganadoressubasta.IdGanadorSubasta = ganadorsbasta.IdGanadorSubasta;
                newganadoressubasta.Subasta = ganadorsbasta.Subasta;
                newganadoressubasta.SubastaId = ganadorsbasta.SubastaId;
                newganadoressubasta.Cantidad = ganadorsbasta.Cantidad;
                newganadoressubasta.ItemId = ganadorsbasta.ItemId;

                var lang = _httpContextAccessor.HttpContext?.Items["lang"] as string ?? "es";
                var client = _httpClientFactory.CreateClient("ApiGatewayService");
                var itemId = Uri.EscapeDataString(ganadorsbasta.ItemId.ToString());
                var idioma = Uri.EscapeDataString(lang);

                var url = $"/auth/api/Item/GetListItem?Itemid={itemId}&lang={idioma}";
                var items = await client.GetAsync(url);

                if (items.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return ResponseApiService.Response(StatusCodes.Status304NotModified, items.RequestMessage);
                }
                var Itemsname = await items.Content.ReadAsStringAsync();
                BaseResponseModel itemsname = JsonConvert.DeserializeObject<BaseResponseModel>(Itemsname);
                ItemDtoResponse itemrequest = itemsname.Data.ToObject<ItemDtoResponse>();

                newganadoressubasta.Item = itemrequest;

                var Proveeddor = await client.GetAsync("/auth/api/Proveedor/GetProveedorById?IdProveedor=" + ganadorsbasta.ProveedorId + "&lang=");
                if (Proveeddor.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return ResponseApiService.Response(StatusCodes.Status304NotModified, Proveeddor.RequestMessage);
                }
                var Proveeddorname = await Proveeddor.Content.ReadAsStringAsync();
                BaseResponseModel Proveeddornameitem = JsonConvert.DeserializeObject<BaseResponseModel>(Proveeddorname);
                List<GeProveedorResponseNew> GetProveedorResponseitem = Proveeddornameitem.Data.ToObject<List<GeProveedorResponseNew>>();

                newganadoressubasta.Proveedor = GetProveedorResponseitem.FirstOrDefault();
                newganadoressubasta.ValorOferta = ganadorsbasta.ValorOferta;

                listganadores.Add(newganadoressubasta);

            }


            return ResponseApiService.Response(StatusCodes.Status200OK,
                listganadores,
                string.Empty);

        }


    }
}
