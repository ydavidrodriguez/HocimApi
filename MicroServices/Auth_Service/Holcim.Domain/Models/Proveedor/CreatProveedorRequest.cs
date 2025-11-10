namespace Holcim.Domain.Models.Proveedor
{
    public class CreatProveedorRequest
    {
        public string? NombreEmpresa { get; set; }
        public Guid? IdiomaId { get; set; }
        public string? RegistroMercantil { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public Guid PaisId { get; set; }
        public Guid ZonaHorariaId { get; set; }
        

    }
}
