namespace Holcim.Provider.Domain.Models
{
    public class RfxReplyResponse
    {
        public Guid IdRfx { get; set; }
        public string? Nombre { get; set; }
        public string? Detalle { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int Consecutivo { get; set; }

    }
}
