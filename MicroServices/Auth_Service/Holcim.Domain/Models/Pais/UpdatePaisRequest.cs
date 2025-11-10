namespace Holcim.Domain.Models.Pais
{
    public class UpdatePaisRequest
    {
        public Guid IdPais { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }
        public string? Indicativo { get; set; }
        public Guid RegionId { get; set; }

    }
}
