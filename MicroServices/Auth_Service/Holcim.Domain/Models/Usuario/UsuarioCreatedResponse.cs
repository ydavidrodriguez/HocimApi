namespace Holcim.Domain.Models.Usuario
{
    public class UsuarioCreatedResponse
    {
        public Guid IdUsuario { get; set; }
        public string Contrasena { get; set; } = string.Empty;
    }
}
