using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models;
using Holcim.AuctionService.Services;
using Microsoft.AspNetCore.Http;


namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public class AgregarTiempoSubastaCommandHandler : IAgregarTiempoSubastaCommandHandler
    {
        // private readonly IDataBaseService _dataBaseService;
        private readonly IDapperProcedure _dapperProcedure;
        private readonly IDataBaseService _dataBaseService;
        private readonly IEstadoService _estadoService;
      

        public AgregarTiempoSubastaCommandHandler(
            IEstadoService estadoService,
            IDapperProcedure dapperProcedure,
            IDataBaseService dataBaseService
            
            )
        {
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
            _estadoService = estadoService;
           
        }

        public async Task<object> Execute(PatchAgregarTiempoSubastaRequest request)
        {


            var subasta = _dataBaseService.Subasta.FirstOrDefault(s => s.IdSubasta == request.IdSubasta);
            if (subasta != null)
            {
                if (subasta.FechaFin.HasValue)
                {
                    subasta.FechaFin = subasta.FechaFin.Value.AddMinutes(request.Minutos);
                    var idSubasta = request.IdSubasta;
                    _dataBaseService.Subasta.Update(subasta);

                    //TrazabilidadSubasta trazabilidadSubasta = new TrazabilidadSubasta();
                    //trazabilidadSubasta.UsuarioId = request.UsuarioId;

                    //trazabilidadSubasta.SubastaId = subasta.IdSubasta;

                    //trazabilidadSubasta.EstadoId = estadoId;
                    //trazabilidadSubasta.FechaCambio = DateTime.Now;

                    await _dataBaseService.SaveAsync();
                }

                return ResponseApiService.Response(StatusCodes.Status200OK, null, "Tiempo Añadito Correctamente.");
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "No se puede encontrar la subasta especificada.");
            }

            //_dataBaseService.TrazabilidadSubasta.Add(trazabilidadSubasta);
            //await _dataBaseService.SaveAsync();
            //var changeData = new { estado = "Extendido", timestamp = DateTime.UtcNow };
            //    await _socketService.EmitNotification(subasta.IdSubasta,changeData);

        }

    }
}
