namespace Holcim.Domain.Entities.Idioma
{
    public class Idioma
    {
        public Guid IdIdioma { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }
        public string? Key { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }

    }
}
