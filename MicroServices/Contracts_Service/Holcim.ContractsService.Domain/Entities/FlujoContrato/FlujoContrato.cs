using Holcim.ContractsService.Domain.Entities.FlujoAprobacion;

namespace Holcim.ContractsService.Domain.Entities.FlujoContrato
{
    public class FlujoContrato
    {
        public Guid IdFlujoContrato { get; set; }
        public Guid FlujoAprobacionId { get; set; }
        public FlujoAprobacion.FlujoAprobacion FlujoAprobacion { get; set; }
        public Contratos.Contrato Contrato { get; set; }
        public Guid ContratoId { get; set; }
        public Guid EstadoId { get; set; }

    }
}
