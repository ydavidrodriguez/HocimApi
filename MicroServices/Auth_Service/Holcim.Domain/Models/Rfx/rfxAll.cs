using Holcim.Domain.Entities.Estado;
namespace Holcim.Domain.Models.Rfx
{
    public class rfxAll
    {
        public Guid IdRfx { get; set; }
        public string? Nombre { get; set; }
        public string? Detalle { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public Estado Estado { get; set; }
        public Guid EstadoId { get; set; }
        public Entities.Moneda.Moneda Moneda { get; set; }
        public Guid MonedaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
        public Guid UsuarioCreacion { get; set; }
        public string? UsuarioCreacionNombre { get; set; }
        public int Consecutivo { get; set; }
        public long? ValorReferencia { get; set; }
        public bool Prueba { get; set; }
        public string? Sitio { get; set; }
        public string? DireccionEntrega { get; set; }


    }
}
