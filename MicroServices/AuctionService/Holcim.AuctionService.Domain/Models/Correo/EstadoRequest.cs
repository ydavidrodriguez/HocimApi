namespace Holcim.AuctionService.Domain.Models.Correo
{
    public class EstadoRequest
    {
        public Guid IdEstado { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
