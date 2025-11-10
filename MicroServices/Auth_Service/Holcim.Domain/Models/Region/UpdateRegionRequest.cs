namespace Holcim.Domain.Models.Region
{
    public class UpdateRegionRequest
    {
        public Guid IdRegion { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

    }
}
