namespace Holcim.Provider.Domain.Models
{
    public class RfxProveedorResponse
    {
        public Guid IdRfx { get; set; }
        public string? Nombre { get; set; }
        public string? Detalle { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public Guid IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public int Consecutivo { get; set; }
        public string EstadoRfx { get; set; }

    }
}
