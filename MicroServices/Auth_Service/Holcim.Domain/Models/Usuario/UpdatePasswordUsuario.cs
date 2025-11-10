namespace Holcim.Domain.Models.Usuario
{
    public class UpdatePasswordUsuario
    {
        public Guid UsuarioId { get; set; }
        public string Contrasena { get; set; } = string.Empty;

    }
}
