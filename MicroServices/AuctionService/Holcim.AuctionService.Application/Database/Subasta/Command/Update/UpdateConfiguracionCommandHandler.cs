using Holcim.AuctionService.Domain.Entities.Subasta;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update;
public class UpdateConfiguracionCommandHandler : IUpdateConfiguracionCommandHandler
{
    private readonly IDataBaseService _dataBaseService;
 

    public UpdateConfiguracionCommandHandler(IDataBaseService dataBaseService)
    {
        _dataBaseService = dataBaseService;
    }

    public  object Execute(PostUpdateConfiguracionRequest request)
    {
        if (request == null || request.SubastaId == Guid.Empty)
        {
            return new { Success = false, Message = "Datos inválidos." };
        }

        // Buscar configuración existente por SubastaId
        var configuracionExistente = _dataBaseService.ConfiguracionSubastaInglesa
            .FirstOrDefault(c => c.SubastaId == request.SubastaId);

        if (configuracionExistente != null)
        {
            // Actualizar configuración existente
            configuracionExistente.MostrarMejorOferta = request.MostrarMejorOferta;
            configuracionExistente.MostrarPosicion = request.MostrarPosicion;
            configuracionExistente.MejorarPropiaPosicion = request.MejorarPropiaPosicion;
            configuracionExistente.PosicionAMejorar = request.PosicionAMejorar;

            _dataBaseService.ConfiguracionSubastaInglesa.Update(configuracionExistente);
        }
        else
        {
            // Crear nueva configuración
            var nuevaConfiguracion = new ConfiguracionSubastaInglesa
            {
                IdConfiguracionSubasta = Guid.NewGuid(),
                SubastaId = request.SubastaId,
                MostrarMejorOferta = request.MostrarMejorOferta,
                MostrarPosicion = request.MostrarPosicion,
                MejorarPropiaPosicion = request.MejorarPropiaPosicion,
                PosicionAMejorar = request.PosicionAMejorar
            };

            _dataBaseService.ConfiguracionSubastaInglesa.AddAsync(nuevaConfiguracion);
        }

        // Guardar cambios
        _dataBaseService.SaveAsync();
        var changeData = new { action = "auction_update", timestamp = DateTime.UtcNow };
       

        return new { Success = true, Message = "Configuración actualizada correctamente." };
    }
}
