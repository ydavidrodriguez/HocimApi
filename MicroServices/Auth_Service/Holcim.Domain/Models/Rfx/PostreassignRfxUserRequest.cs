namespace Holcim.Domain.Models.Rfx
{
    public class PostreassignRfxUserRequest
    {
        public Guid Motivo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public List<Guid>? UsuarioId { get; set; }
        public Guid RfxId { get; set; }

    }
}
