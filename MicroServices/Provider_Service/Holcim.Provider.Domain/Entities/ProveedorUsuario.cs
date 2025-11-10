namespace Holcim.Provider.Domain.Entities
{
    public class ProveedorUsuario
    {
        public Guid IdProveedorUsuario { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid ProveedorId { get; set; }
        public bool Estado { get; set; }

    }
}
