namespace Holcim.AuctionService.Domain.Entities.Subasta
{
    public class TipoSubasta
    {
        public Guid IdTipoSubasta { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
