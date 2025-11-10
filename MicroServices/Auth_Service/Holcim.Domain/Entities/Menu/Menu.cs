namespace Holcim.Domain.Entities.Menu
{
    public class Menu
    {
        public Guid IdMenu { get; set; }
        public string? Nombre { get; set; }
        public string? PathFront { get; set; }
        public Guid? IdPadre { get; set; }
        public bool Estado { get; set; }
        public string? Componente { get; set; }
        public int? FormularioInterno { get; set; }
        public int Posicion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }


    }
}
