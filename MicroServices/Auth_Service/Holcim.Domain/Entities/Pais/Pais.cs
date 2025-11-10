namespace Holcim.Domain.Entities.Pais
{
    public class Pais
    {
        public Guid IdPais { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }
        public string? Indicativo { get; set; }
        public Region.Region Region { get; set; }
        public Guid RegionId { get; set; }
        public TipoPais.TipoPais TipoPais { get; set; }
        public Guid TipoPaisId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }

    }
}
