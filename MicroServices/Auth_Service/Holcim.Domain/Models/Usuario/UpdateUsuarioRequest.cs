namespace Holcim.Domain.Models.Usuario
{
    public class UpdateUsuarioRequest
    {
        public Guid IdCuentaAdmin { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid PaisId { get; set; }
        public bool Estado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public List<Guid> RolId { get; set; }
        public bool EstadoUsuario { get; set; }

    }
}
