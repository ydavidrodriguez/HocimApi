namespace Holcim.Domain.Entities.Acciones
{
    public class Acciones
    {
        public Guid IdAcciones { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }


    }
}
