namespace Holcim.Provider.Domain.Models
{
    public class CreatProveedorRequest
    {
        public string? NombreEmpresa { get; set; }
        public Guid? IdiomaId { get; set; }
        public string? RegistroMercantil { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public Guid PaisId { get; set; }
        public Guid ZonaHorariaId { get; set; }

    }
}
