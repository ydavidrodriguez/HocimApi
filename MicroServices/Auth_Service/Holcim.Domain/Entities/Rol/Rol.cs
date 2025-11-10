namespace Holcim.Domain.Entities.Rol
{
    public class Rol
    {
        public Guid IdRol { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
    }
}
