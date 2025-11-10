namespace Holcim.Domain.Entities.TipoRfx
{
    public class TipoRfx
    {
        public Guid IdTipoRfx { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }

    }
}
