namespace Holcim.Domain.Entities.Notificaciones
{
    public class Notificaciones
    {
        public Guid IdNotificaciones { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }

    }
}
