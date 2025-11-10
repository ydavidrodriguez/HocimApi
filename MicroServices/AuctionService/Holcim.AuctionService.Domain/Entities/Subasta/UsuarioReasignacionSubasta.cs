namespace Holcim.AuctionService.Domain.Entities.Subasta
{
    public class UsuarioReasignacionSubasta
    {
        public Guid IdUsuarioReasignacionSubasta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public Subasta Subasta { get; set; }
        public Guid SubastaId { get; set; }
        public string? Usuarios { get; set; }
        public bool Estado { get; set; }   
        public Guid? UsuarioOld { get; set; }   
        public Guid MotivoId { get; set; }   

    }
}
