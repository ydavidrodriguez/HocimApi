using Holcim.Domain.Entities.Pscs;

namespace Holcim.Domain.Entities.Moneda
{
    public class Moneda
    {
        public Guid IdMoneda { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
    }
}
