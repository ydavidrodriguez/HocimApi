namespace Holcim.Domain.Models.Usuario
{
    public class GetUsuarioResponse
    {
        public Guid IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public bool Estado { get; set; }

    }
}
