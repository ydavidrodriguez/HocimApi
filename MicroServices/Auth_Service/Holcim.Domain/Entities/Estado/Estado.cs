namespace Holcim.Domain.Entities.Estado
{
    public class Estado
    {
        public Guid IdEstado { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
        public TipoEstado.TipoEstado TipoEstado { get; set; }
        public Guid TipoEstadoId { get; set; }
        public bool Activo { get; set; }

    }
}
