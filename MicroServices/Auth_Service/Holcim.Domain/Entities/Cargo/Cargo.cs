namespace Holcim.Domain.Entities.Cargo
{
    public class Cargo
    {
        public Guid IdCargo { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }


    }
}
