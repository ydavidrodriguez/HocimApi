namespace Holcim.ContractsService.Domain.Entities.FlujoAprobacion
{
    public class FlujoAprobacion
    {
        public Guid IdFlujoAprobacion { get; set; }
        public string? Nombre { get; set; }
        public Guid RegionId { get; set; }
        public bool Estado { get; set; } 
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
