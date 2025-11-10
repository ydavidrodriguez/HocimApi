using Holcim.ContractsService.Domain.Entities.Contratos;

namespace Holcim.ContractsService.Domain.Entities.Pasos
{
    public class PasosTipoContrato
    {
        public Guid IdPasosTipoContrato { get; set; }
        public PasoFlujo PasoFlujo { get; set; }
        public Guid PasoFlujoId { get; set; }
        public TipoContrato TipoContrato { get; set; }
        public Guid TipoContratoId { get; set; }

    }
}
