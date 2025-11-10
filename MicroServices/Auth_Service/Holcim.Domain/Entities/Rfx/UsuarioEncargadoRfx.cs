namespace Holcim.Domain.Entities.Rfx
{
    public class UsuarioEncargadoRfx
    {
        public Guid IdUsuarioEncargadoRfx { get; set; }
        public Rfx Rfx { get; set; }
        public Guid RfxId { get; set; }
        public Usuario.Usuario Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public bool Estado { get; set; }

    }
}
