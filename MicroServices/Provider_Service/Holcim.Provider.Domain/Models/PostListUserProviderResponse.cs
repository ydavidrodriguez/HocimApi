namespace Holcim.Provider.Domain.Models
{
    public class PostListUserProviderResponse
    {
        public Guid IdProveedorUsuario { get; set; }
        public Guid UsuarioId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreEmpresa { get; set; } = string.Empty;
        public Guid ProveedorId { get; set; }
        public bool Estado { get; set; }


    }
}
