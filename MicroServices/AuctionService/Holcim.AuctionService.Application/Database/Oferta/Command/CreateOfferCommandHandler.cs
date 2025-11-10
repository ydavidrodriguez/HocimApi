using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Holcim.AuctionService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Holcim.AuctionService.Services;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Create
{
    public class CreateOfferCommandHandler : ICreateOfferCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IEstadoService _estadoService;
  
        public CreateOfferCommandHandler(IEstadoService estadoService, IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
            _estadoService = estadoService;
        }

        public async Task<object> Execute(PostCreateOfferRequest request)
        {
            var subasta = _dataBaseService.Subasta.FirstOrDefault(s => s.IdSubasta == request.SubastaId);
            if (subasta == null)
            {
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "No se encontró la subasta especificada.");
            }
            if (subasta.EstadoId != await _estadoService.GetEstadoIdByNameAsync("En Curso")){
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "No es posible hacer una oferta si la subasta no se encuentra en curso");
            }
            var configuracion = _dataBaseService.ConfiguracionSubastaInglesa
                .FirstOrDefault(c => c.SubastaId == request.SubastaId);

            if (configuracion != null)
            {
                if (configuracion.MejorarPropiaPosicion == true)
                {
                    var propiasOfertas = _dataBaseService.OfertaSubasta
                        .Where(o => o.SubastaId == request.SubastaId && o.ItemId == request.ItemId && o.UsuarioId == request.UsuarioId)
                        .OrderByDescending(o => subasta.Directo ? o.ValorOferta : -o.ValorOferta)
                        .ToList();

                    var mejorPropiaOferta = propiasOfertas.FirstOrDefault()?.ValorOferta;

                    if (mejorPropiaOferta.HasValue)
                    {
                        bool esMejorOferta = subasta.Directo
                            ? request.ValorOferta > mejorPropiaOferta
                            : request.ValorOferta < mejorPropiaOferta;

                        if (!esMejorOferta)
                        {
                            return ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "La nueva oferta debe ser mejor que su propia mejor oferta.");
                        }
                    }
                }
                else if (configuracion.PosicionAMejorar.HasValue && configuracion.PosicionAMejorar > 0)
                {
                    var ofertasDelItem = _dataBaseService.OfertaSubasta
                        .Where(o => o.SubastaId == request.SubastaId && o.ItemId == request.ItemId)
                        .OrderByDescending(o => subasta.Directo ? o.ValorOferta : -o.ValorOferta)
                        .ToList();

                    var ofertaEnPosicion = ofertasDelItem.ElementAtOrDefault(configuracion.PosicionAMejorar.Value - 1);

                    if (ofertaEnPosicion != null)
                    {
                        bool esMejorOferta = subasta.Directo
                            ? request.ValorOferta > ofertaEnPosicion.ValorOferta
                            : request.ValorOferta < ofertaEnPosicion.ValorOferta;

                        if (!esMejorOferta)
                        {
                            return ResponseApiService.Response(StatusCodes.Status400BadRequest, null, $"La oferta debe ser mejor que la oferta en la posición {configuracion.PosicionAMejorar}.");
                        }
                    }
                }
            }
            OfertaSubasta new_offer = new OfertaSubasta();
            new_offer.IdOfertaSubasta = Guid.NewGuid();
            new_offer.SubastaId = request.SubastaId;
            new_offer.ItemId = request.ItemId;
            new_offer.ValorOferta = request.ValorOferta;
            new_offer.UsuarioId = request.UsuarioId;
            new_offer.ProveedorId = request.ProveedorId;
            new_offer.FechaCreacion = DateTime.UtcNow;
            _dataBaseService.OfertaSubasta.Add(new_offer);
            await _dataBaseService.SaveAsync();
            var changeData = new { action = "new_offer", timestamp = DateTime.UtcNow };
    
            return ResponseApiService.Response(StatusCodes.Status201Created, request);

        }

    }
}
