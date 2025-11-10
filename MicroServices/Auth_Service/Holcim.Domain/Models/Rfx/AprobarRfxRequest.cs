namespace Holcim.Domain.Models.Rfx
{
    public class AprobarRfxRequest
    {
        public List<Guid> ProveedorId { get; set; }
        public Guid RfxId { get; set; }
        public Guid UsuarioId { get; set; }

    }
}
