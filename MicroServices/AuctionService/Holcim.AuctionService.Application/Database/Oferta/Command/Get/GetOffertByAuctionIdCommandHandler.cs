using AutoMapper;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models.Items;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Auction.Commands.GetById
{
    public class GetOffertByAuctionIdCommandHandler : IGetOffertByAuctionIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetOffertByAuctionIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper, IDapperProcedure dapperProcedure)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
        }

        public async Task<object> Execute(Guid auctionId, Guid? userId)
        {
            var subasta = _dataBaseService.Subasta.FirstOrDefault(s => s.IdSubasta == auctionId);
            if (subasta == null)
            {
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "No se encontró la subasta especificada.");
            }
            var configuracion = _dataBaseService.ConfiguracionSubastaInglesa
                .FirstOrDefault(c => c.SubastaId == auctionId);


            var encargado = _dataBaseService.UsuarioEncargadoSubasta.FirstOrDefault(s => s.UsuarioId == userId && s.SubastaId == auctionId);
            var colaborador = _dataBaseService.UsuarioColaboradorSubasta.FirstOrDefault(s => s.UsuarioId == userId && s.SubastaId == auctionId);
            bool showMejorOferta = true;
            bool showPosicion = true;
            if (!(userId == subasta.UsuarioCreacionId || encargado != null || colaborador != null))
            {
                showMejorOferta = configuracion?.MostrarMejorOferta ?? false;
                showPosicion = configuracion?.MostrarPosicion ?? false;
            }

            var ofertasAgrupadasPorItem = _dataBaseService.OfertaSubasta
                .Where(t => t.SubastaId == auctionId)
                .GroupBy(o => o.ItemId)
                .Select(g => new
                {
                    ItemId = g.Key,
                    Ofertas = subasta.Directo
                        ? g.OrderByDescending(o => o.ValorOferta).ToList()
                        : g.OrderBy(o => o.ValorOferta).ToList()
                })
                .ToList();
            // Calcular mejor oferta y posiciones globales
            var items = ofertasAgrupadasPorItem
            .Select(g =>
            {
                // Obtener información del item
                var parametersItems = new { IdItem = g.ItemId };
                var itemString = _dapperProcedure.GetQuery(parametersItems, "GETITEMSBYID");
                var item = JsonConvert.DeserializeObject<List<GetItemsSubasta>>(itemString)?.FirstOrDefault();

                // Mejor oferta global por item
                var mejorOferta = showMejorOferta ? g.Ofertas.FirstOrDefault()?.ValorOferta : (decimal?)null;

                // Calcular posición global para cada oferta del item
                var ofertasConPosicionGlobal = g.Ofertas
                    .Select((o, index) => new OfertaSubastaDto
                    {
                        IdOfertaSubasta = o.IdOfertaSubasta,
                        SubastaId = o.SubastaId,
                        ItemId = o.ItemId,
                        ValorOferta = o.ValorOferta,
                        UsuarioId = o.UsuarioId,
                        ProveedorId = o.ProveedorId,
                        FechaCreacion = o.FechaCreacion,
                        Posicion = showPosicion ? index + 1 : (int?)null
                    })
                    .ToList();

                // Agrupar ofertas por empresa de proveedor
                var ofertasPorUsuario = new Dictionary<string, List<OfertaSubastaDto>>();
                if (userId == subasta.UsuarioCreacionId || encargado != null || colaborador != null)
                {
                    ofertasPorUsuario = ofertasConPosicionGlobal
                        .GroupBy(o => o.UsuarioId)
                        .ToDictionary(
                            g =>
                            {
                                string empresaNombre = "Proveedor desconocido";
                                Guid? proveedorId = null;
                                if (g.Key.HasValue)
                                {
                                    var parametersProveedor = new { UsuarioId = g.Key.Value };
                                    var proveedorString = _dapperProcedure.GetQuery(parametersProveedor, "GETPROVEEDORBYUSUARIOID");

                                    if (!string.IsNullOrEmpty(proveedorString))
                                    {
                                        var proveedor = JsonConvert.DeserializeObject<List<dynamic>>(proveedorString)?.FirstOrDefault();
                                        if (proveedor != null && proveedor.NombreEmpresa != null)
                                        {
                                            empresaNombre = proveedor.NombreEmpresa;
                                            proveedorId = proveedor.IdProveedor;
                                        }
                                    }
                                }
                                foreach (var oferta in g)
                                {
                                    oferta.ProveedorId = proveedorId ?? Guid.Empty;
                                }
                                return empresaNombre;
                            },
                            g => g.ToList()
                        );
                }
                else
                {
                    ofertasPorUsuario = ofertasConPosicionGlobal
                        .Where(o => o.UsuarioId == userId)
                        .GroupBy(o => o.UsuarioId)
                        .ToDictionary(
                            g =>
                            {
                                string empresaNombre = "Proveedor desconocido";
                                Guid? proveedorId = null;
                                if (g.Key.HasValue)
                                {
                                    var parametersProveedor = new { UsuarioId = g.Key.Value };
                                    var proveedorString = _dapperProcedure.GetQuery(parametersProveedor, "GETPROVEEDORBYUSUARIOID");

                                    if (!string.IsNullOrEmpty(proveedorString))
                                    {
                                        var proveedor = JsonConvert.DeserializeObject<List<dynamic>>(proveedorString)?.FirstOrDefault();
                                        if (proveedor != null && proveedor.NombreEmpresa != null)
                                        {
                                            empresaNombre = proveedor.NombreEmpresa;
                                            proveedorId = proveedor.IdProveedor;
                                        }
                                    }
                                }
                                foreach (var oferta in g)
                                {
                                    oferta.ProveedorId = proveedorId ?? Guid.Empty;
                                }
                                return empresaNombre;
                            },
                            g => g.ToList()
                        );
                }

                return new
                {
                    g.ItemId,
                    Item = item,
                    MejorOferta = mejorOferta,
                    OfertasPorUsuario = ofertasPorUsuario
                };
            })
            .ToList();

            // Formatear la respuesta final
            var resultado = items
                .OrderBy(i => i.Item.Index)
                .Select(i => new
                {
                    i.Item.Index,
                    i.ItemId,
                    i.Item.Nombre,
                    Cantidad = i.Item.Cantidad,
                    UdmCode = i.Item.UdmCode,
                    Moneda = i.Item.NombreMoneda,
                    MejorOferta = i.MejorOferta,
                    OfertasPorUsuario = i.OfertasPorUsuario
                });

            return ResponseApiService.Response(StatusCodes.Status200OK, resultado);

        }
    }
}
