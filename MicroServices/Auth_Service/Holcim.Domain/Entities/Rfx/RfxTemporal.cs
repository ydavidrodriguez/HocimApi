using Holcim.Domain.Entities.Estado;

namespace Holcim.Domain.Entities.Rfx
{
    public class RfxTemporal
    {
        public Guid IdRfxTemporal { get; set; }
        public string JsonRfx { get; set; }
        public Estado.Estado Estado { get; set; }
        public Guid EstadoId { get; set; }
    }
}
