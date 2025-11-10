namespace Holcim.ContractsService.Domain.Entities.Aprobaciones
{
    public class AprobacionPasoFlujo
    {
        public Guid IdAprobacionPasoFlujo { get; set; }
        public Guid ContratoId { get; set; }
        public Guid FlujoAprobacionId { get; set; }
        public Guid PasoFlujoId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Aprobacion { get; set; }


    }
}
