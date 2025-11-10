using Holcim.Domain.Entities.Pscs;
using System.Numerics;

namespace Holcim.Domain.Models.Rfx
{
    public class RfxItemResponse
    {
        public Guid IdItem { get; set; }
        public string Nombre { get; set; }
        public Entities.UnidadMedida.UnidadMedida UnidadMedida { get; set; }
        public Pscs Pscs { get; set; }
        public long Cantidad { get; set; }
        public long valorUnidad { get; set; }
        public List<Entities.PreguntaArchivo.PreguntaArchivo> LispreguntaArchivo { get; set; }   
        public bool Estado { get; set; }
        public bool VisibleProveedor { get; set; }
        public string? Detalle { get; set; }
        public int? Index { get; set; }

    }
}
