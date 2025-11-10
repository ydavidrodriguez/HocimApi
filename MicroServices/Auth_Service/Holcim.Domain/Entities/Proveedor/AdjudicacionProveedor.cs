namespace Holcim.Domain.Entities.Proveedor
{
    public class AdjudicacionProveedor
    {
        public Guid IdAdjudicacionProveedor { get; set; }
        public Item.Item Item { get; set; }
        public Guid ItemId { get; set; }
        public Proveedor Proveedor { get; set; }
        public Guid ProveedorId { get; set; }
        public Rfx.Rfx Rfx { get; set; }
        public Guid RfxId { get; set; }
        public DateTime FechaAdjudicacion { get; set; }
        public bool Estado { get; set; }

    }
}
