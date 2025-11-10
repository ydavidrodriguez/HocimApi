namespace Holcim.Domain.Models.Proveedor
{
    public class UpdateProveedorRequest
    {
        public Guid IdProveedor { get; set; }
        public string NombreEmpresa { get; set; }
        public Guid? IdiomaId { get; set; }
        public Guid PaisId { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
        public Guid ZonaHorariaId { get; set; }

    }
}
