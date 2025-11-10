namespace Holcim.ContractsService.Domain.Entities.Contratos
{
    public class TipoContrato
    {
        public Guid IdTipoContrato { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }    
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
