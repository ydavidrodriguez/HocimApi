namespace Holcim.ContractsService.Domain.Entities.Contratos
{
    public class Contrato
    {
        public Guid IdContrato { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public Guid ProveedorId { get; set; }
        public Guid RegionId { get; set; }
        public Guid PaisId { get; set; } 
        public long Monto { get; set; }
        public Guid MonedaId { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
        public TipoContrato TipoContrato { get; set; }
        public Guid TipoContratoId { get; set; }
        public Guid EstadoId { get; set; }
        public string? Path { get; set; }
        

    }
}
