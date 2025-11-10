namespace Holcim.Provider.Domain.Models.Proveedor
{
    public class PostCreateUserProveedor
    {
        public Guid IdProveedor { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
    }
}
