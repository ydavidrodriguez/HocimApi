using Holcim.Domain.Entities.PreguntaArchivo;
using Holcim.Domain.Entities.ProveedorRfx;
using Holcim.Domain.Entities.Rfx;

namespace Holcim.Domain.Models.Rfx
{
    public class RfxResponse
    {
        public Entities.Rfx.Rfx Rfx { get; set; }
        public List<RfxItemResponse> RfxItem { get; set; }
        public List<ProveedorRfx> InvitacionProveedorRfx { get; set; }
        public List<RfxPais> ListGru { get; set; }
        public List<ListPreguntaSobreRfx> PreguntaSobreRfx { get; set; }

    }
}
