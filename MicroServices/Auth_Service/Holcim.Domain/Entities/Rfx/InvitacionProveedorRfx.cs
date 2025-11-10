namespace Holcim.Domain.Entities.Rfx
{
    public class InvitacionProveedorRfx
    {
        public Guid IdInvitacionProveedorRfx { get; set; }
        public Rfx Rfx { get; set; }
        public Guid RfxId { get; set; }
        public string? Correo { get; set; }

    }
}
