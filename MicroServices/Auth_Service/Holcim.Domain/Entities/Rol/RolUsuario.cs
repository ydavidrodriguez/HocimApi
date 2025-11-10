namespace Holcim.Domain.Entities.Rol
{
    public class RolUsuario
    {
        public Guid IdRolUsuario { get; set; }
        public Rol Rol { get; set; }
        public Guid RolId { get; set; }
        public Usuario.Usuario Usuario { get; set; }
        public Guid UsuarioId { get; set; }

    }
}
