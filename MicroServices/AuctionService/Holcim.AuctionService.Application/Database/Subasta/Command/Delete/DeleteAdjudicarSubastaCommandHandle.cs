using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.AspNetCore.Http;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Delete
{
    public class DeleteAdjudicarSubastaCommandHandle : IDeleteAdjudicarSubastaCommandHandle
    {
        private readonly IDataBaseService _dataBaseService;


        public DeleteAdjudicarSubastaCommandHandle(

            IDataBaseService dataBaseService

         )
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<object> Execute(DeleteOtorgadoRequest deleteOtorgadoRequest)
        {
            if (deleteOtorgadoRequest.IdGanadorSubasta != null)
            {

                var GanadorSubasta = _dataBaseService.GanadorSubasta.Where(x => x.IdGanadorSubasta == deleteOtorgadoRequest.IdGanadorSubasta).FirstOrDefault();

                if (GanadorSubasta != null)
                {
                    _dataBaseService.GanadorSubasta.Remove(GanadorSubasta);
                    await _dataBaseService.SaveAsync();
                }
            }
            else
            {
                var respuestaronda = _dataBaseService.RespuestaRonda.
                    Where(x => x.RondaId == deleteOtorgadoRequest.Rondaid && x.ItemsRondaId == deleteOtorgadoRequest.ItemRondaId).FirstOrDefault();
                if (respuestaronda != null)
                {
                    respuestaronda.Otorgado = false;
                    _dataBaseService.RespuestaRonda.Update(respuestaronda);
                    await _dataBaseService.SaveAsync();
                }
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, deleteOtorgadoRequest, string.Empty);
        }

    }
}
