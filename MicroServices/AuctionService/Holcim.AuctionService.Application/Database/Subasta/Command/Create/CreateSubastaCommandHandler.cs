using AutoMapper;
using Azure.Core;
using Holcim.AuctionService.Application.Database.Auction.Commands.Invite;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Entities.ItemSubasta;
using Holcim.AuctionService.Domain.Entities.Region;
using Holcim.AuctionService.Domain.Models;
using Holcim.AuctionService.Domain.Models.Auction;
using Holcim.AuctionService.Domain.Models.Correo;
using Holcim.AuctionService.Domain.Models.Items;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Create
{
    public class CreateSubastaCommandHandler : ICreateSubastaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;
        private readonly IInviteProviderCommandHandler _inviteProviderHandler;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CreateSubastaCommandHandler(
            IDataBaseService dataBaseService,
            IMapper mapper,
            IDapperProcedure dapperProcedure,
            IInviteProviderCommandHandler inviteProviderHandler,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor
           )
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            _inviteProviderHandler = inviteProviderHandler;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<object> Execute(PostCreateSubastaRequest postCreateSubastaRequest)
        {
            var client = _httpClientFactory.CreateClient("ApiGatewayService");

            if (_dataBaseService.Subasta.Where(x => x.Titulo == postCreateSubastaRequest.Titulo).FirstOrDefault() == null)
            {
                var lang = _httpContextAccessor.HttpContext?.Items["lang"] as string ?? "es";
                var nombre = Uri.EscapeDataString("En Curso");
                var tipoEstado = Uri.EscapeDataString("subasta");
                var idioma = Uri.EscapeDataString(lang);

                var url = $"/auth/api/Estado/GetListEstadoAll?Nombre={nombre}&TipoEstado={tipoEstado}&lang={idioma}";
                var estado = await client.GetAsync(url);

                if (estado.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return ResponseApiService.Response(StatusCodes.Status304NotModified, estado.RequestMessage);
                }
                var dataEstado = await estado.Content.ReadAsStringAsync();
                BaseResponseModel Estado = JsonConvert.DeserializeObject<BaseResponseModel>(dataEstado);
                List<EstadoRequest> estadoid = Estado.Data.ToObject<List<EstadoRequest>>();

                Domain.Entities.Subasta.Subasta subastanew = _mapper.Map<Domain.Entities.Subasta.Subasta>
                (postCreateSubastaRequest);
                subastanew.IdSubasta = Guid.NewGuid();
                subastanew.UsuarioCreacionId = postCreateSubastaRequest.UsuarioCreacionId;
                subastanew.FechaCreacion = DateTime.Now;
                subastanew.EstadoId = estadoid.FirstOrDefault().IdEstado;


                _dataBaseService.Subasta.Add(subastanew);

                //En caso que no tenga un rfx asociado

                if (postCreateSubastaRequest.postListItemsRequests != null && postCreateSubastaRequest.postListItemsRequests.Count > 0)
                {
                    foreach (var ItemnewSubasta in postCreateSubastaRequest.postListItemsRequests)
                    {
                        var newitem = new List<ItemRequestCreate> {
                            new ItemRequestCreate{
                            nombre= ItemnewSubasta.Nombre,
                            unidadMedidaId= ItemnewSubasta.UnidadMedidaId,
                            cantidad = ItemnewSubasta.Cantidad,
                            valorUnidad = ItemnewSubasta.valorUnidad,
                            observacion = "",
                            monedaId = postCreateSubastaRequest.MonedaId,
                            index = ItemnewSubasta.Index,
                            }

                        };
                        var json = JsonConvert.SerializeObject(newitem);
                        var jsonContent = new StringContent(json,
                            Encoding.UTF8, "application/json");


                        var response = await client.PostAsync("/auth/api/Item/PostCreateItem?lang=", jsonContent);

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var dataItem = await response.Content.ReadAsStringAsync();
                            var datofinal = JsonConvert.DeserializeObject<BaseResponseModel>(dataItem);

                            ItemSubasta itemSubasta = new ItemSubasta();

                            itemSubasta.IdItemSubasta = Guid.NewGuid();
                            itemSubasta.SubastaId = subastanew.IdSubasta;
                            itemSubasta.ItemId = Guid.Parse(datofinal.Data);

                            _dataBaseService.ItemSubasta.Add(itemSubasta);

                        }
                        else { return ResponseApiService.Response(StatusCodes.Status304NotModified, response.RequestMessage); }
                    }
                }

                if (postCreateSubastaRequest.GRUs != null)
                {
                    foreach (var pais in postCreateSubastaRequest.GRUs)
                    {
                        PaisSubasta regionSubasta = new PaisSubasta();
                        regionSubasta.IdPaisSubasta = Guid.NewGuid();
                        regionSubasta.SubastaId = subastanew.IdSubasta;
                        regionSubasta.IdPais = pais;

                        _dataBaseService.PaisSubasta.Add(regionSubasta);
                    }
                }

                //TrazabilidadSubasta trazabilidadSubasta = new TrazabilidadSubasta();

                //trazabilidadSubasta.SubastaId = subastanew.IdSubasta;
                //trazabilidadSubasta.EstadoId = postCreateSubastaRequest.EstadoId ?? Guid.Empty;
                //trazabilidadSubasta.FechaCambio = DateTime.Now;
                //trazabilidadSubasta.UsuarioId = postCreateSubastaRequest.UsuarioCreacionId ?? Guid.Empty; ;

                //_dataBaseService.TrazabilidadSubasta.Add(trazabilidadSubasta);


                if (postCreateSubastaRequest.proveedoresInvitados != null)
                {
                    var correos = postCreateSubastaRequest.proveedoresInvitados;
                    InviteProviderRequest request = new InviteProviderRequest();
                    request.AuctionId = subastanew.IdSubasta;
                    request.ProviderEmails = correos;
                    await _inviteProviderHandler.Execute(request);
                }

                await _dataBaseService.SaveAsync();
                postCreateSubastaRequest.IdSubasta = subastanew.IdSubasta;
                return ResponseApiService.Response(StatusCodes.Status201Created, postCreateSubastaRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Subasta Ya Registrada");

            }

        }

    }
}
