using System.Numerics;

namespace Holcim.Domain.Entities.Item
{
    public class ItemDetalle
    {
        public Guid IdItemDetalle { get; set; }
        public Item Item { get; set; }
        public Guid ItemId { get; set; }
        public UnidadMedida.UnidadMedida UnidadMedida { get; set; }
        public Guid UnidadMedidaId { get; set; }
        public Pscs.Pscs? Pscs { get; set; }
        public Guid? PscsId { get; set; }
        public long Cantidad { get; set; }
        public long? valorUnidad { get; set; }
        public bool? VisualizacionPrecioProveedor { get; set; }
        public string? Observacion { get; set; }
        public Guid? MonedaId { get; set; }
     

    }
}
