using AutoMapper;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models.Subasta;
using Microsoft.AspNetCore.Http;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public class UpdateReanudarSubastaCommandHandler : IUpdateReanudarSubastaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateReanudarSubastaCommandHandler(
        IMapper mapper,
        IDataBaseService dataBaseService
        )
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<object> Execute(PutSubastaFechaPausaRequest putSubastaFechaPausaRequest)
        {
            Domain.Entities.Subasta.Subasta subasta = _dataBaseService.Subasta.Where(x => x.IdSubasta == putSubastaFechaPausaRequest.SubastaId).FirstOrDefault();
            if (subasta != null)
            {
                TimeSpan diferencia = (putSubastaFechaPausaRequest.FechaReanudacion.Value - subasta.FechaPausa.Value);
                subasta.FechaFin = subasta.FechaFin.Value.AddSeconds(diferencia.Seconds);
                subasta.FechaPausa = null;
                _dataBaseService.Subasta.Update(subasta);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, subasta.FechaFin, "Fecha actualizada exitosamente.");
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status203NonAuthoritative, new object(), "Subasta no encontrada.");
            }

        }

    }
}
