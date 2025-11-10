namespace Holcim.AuctionService.Domain.Entities.Subasta
{
    public class UsuarioEncargadoSubasta
    {
        public Guid IdUsuarioEncargadoSubasta { get; set; }
        public Subasta Subasta { get; set; }
        public Guid SubastaId { get; set; }
        public Guid UsuarioId { get; set; }
        public bool Estado { get; set; }

    }
}
