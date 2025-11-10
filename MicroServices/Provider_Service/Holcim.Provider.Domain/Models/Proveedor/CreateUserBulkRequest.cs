namespace Holcim.Provider.Domain.Models.Proveedor
{
    public class CreateUserBulkRequest
    {
        public string? NombreEmpresa { get; set; }
        public string? RegistroMercantil { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public Guid PaisId { get; set; }
        public string? Telefono { get; set; }
        public string? Indicativo { get; set; }
        public Guid ZonaHorariaId { get; set; }
        public string? Tipo { get; set; }
        public List<CreateUsuariosRequest> Usuarios { get; set; }

    }
}
