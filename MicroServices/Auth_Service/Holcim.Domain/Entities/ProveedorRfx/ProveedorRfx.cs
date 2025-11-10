namespace Holcim.Domain.Entities.ProveedorRfx
{
    public class ProveedorRfx
    {
        public Guid IdProveedorRfx { get; set; }
        public Rfx.Rfx Rfx { get; set; }
        public Guid RfxId { get; set; }
        public Proveedor.Proveedor Proveedor { get; set; }
        public Guid ProveedorId { get; set; }
        public Estado.Estado Estado { get; set; }
        public Guid EstadoId { get; set; }

    }
}
