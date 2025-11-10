namespace Holcim.Domain.Entities.Dependencia
{
    public class Departamento
    {
        public Guid IdDepartamento { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }

    }
}
