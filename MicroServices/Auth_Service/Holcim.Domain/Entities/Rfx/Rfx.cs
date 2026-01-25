namespace Holcim.Domain.Entities.Rfx
{
    public class Rfx
    {
        public Guid IdRfx { get; set; }
        public string? Nombre { get; set; }
        public string? Detalle { get; set; }
        public TipoRfx.TipoRfx TipoRfx { get; set; }
        public Guid TipoRfxId { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public Estado.Estado Estado { get; set; }
        public Guid EstadoId { get; set; }
        public Moneda.Moneda Moneda { get; set; } 
        public Guid MonedaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
        public Guid UsuarioCreacion { get; set; }
        public int Consecutivo { get; set; }
        public long? ValorReferencia { get; set; }
        public bool Prueba { get; set; }
        public string? Path { get; set; }
        public string? Sitio { get; set; }
        public string? DireccionEntrega { get; set; }

    }
}
