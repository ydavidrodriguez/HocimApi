namespace Holcim.Provider.Domain.Models.Usuario
{
    public class PutUsuarioUpdateRequest
    {
        public Guid IdProveedor { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public bool Estado { get; set; }
        public Guid IdUsuario { get; set; }

    }
}
