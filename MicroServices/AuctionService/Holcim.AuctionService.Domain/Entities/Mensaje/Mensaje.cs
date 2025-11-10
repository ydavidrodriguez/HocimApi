namespace Holcim.AuctionService.Domain.Entities.Mensaje
{
    public class Mensaje
    {
        public Guid IdMensaje { get; set; }
        public Guid SubastaId { get; set; }
        public Guid UsuarioId { get; set; }
        public string? Mensajes { get; set; }
        public bool visto { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
