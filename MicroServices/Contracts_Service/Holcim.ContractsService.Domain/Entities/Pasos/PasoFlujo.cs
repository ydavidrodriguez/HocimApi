namespace Holcim.ContractsService.Domain.Entities.Pasos
{
    public class PasoFlujo
    {
        public Guid IdPasoFlujo { get; set; }
        public long Maximo { get; set; }
        public long Minimo { get; set; }
        public int Order { get; set; }
        public Guid TipoMonedaId { get; set; }
        public bool Estado { get; set; }
        public FlujoAprobacion.FlujoAprobacion FlujoAprobacion { get; set; }
        public Guid FlujoAprobacionId { get; set; }

    }
}
