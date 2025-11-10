namespace Holcim.AuctionService.Domain.Entities.Ronda
{
    public class RespuestaRonda
    {
        public Guid RespuestaRondaId { get; set; }
        public Guid ItemsRondaId { get; set; }
        public Guid UsuarioRondaId { get; set; }
        public string? Respuesta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid RondaId { get; set; }
        public bool? Otorgado { get; set; }

    }
}
