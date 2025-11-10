namespace Holcim.Provider.Domain.Models
{
    public class CreateUserProviderRequest
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public Guid ProveedorId { get; set; }

    }
}
