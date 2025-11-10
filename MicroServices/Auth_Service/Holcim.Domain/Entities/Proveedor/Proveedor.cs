namespace Holcim.Domain.Entities.Proveedor
{
    public class Proveedor
    {
        public Guid IdProveedor { get; set; }
        public string NombreEmpresa { get; set; } = string.Empty;
        public Guid? IdiomaId { get; set; }
        public Idioma.Idioma Idioma { get; set; }
        public string RegistroMercantil { get; set; } = string.Empty;
        public Guid PaisId { get; set; }
        public Pais.Pais Pais { get; set; }
        public Guid? UsuarioId { get; set; }
        public Usuario.Usuario? Usuario { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
        public ZonaHoraria.ZonaHoraria ZonaHoraria  { get; set; }  
        public Guid ZonaHorariaId { get; set; }   

    }
}
