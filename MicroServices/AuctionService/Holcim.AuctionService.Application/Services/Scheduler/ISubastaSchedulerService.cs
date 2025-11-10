using Holcim.AuctionService.Domain.Entities.Subasta;

public interface ISubastaSchedulerService
{
    Task ProgramarSubastaAsync(
            ConfiguracionSubastaInglesa config,
            DateTime horaInicio,
            DateTime horaFin);
    Task ActualizarSubastaAsync(Guid subastaId, DateTime nuevaHoraInicio, DateTime nuevaHoraFin);
    Task CancelarSubastaAsync(Guid subastaId);
}