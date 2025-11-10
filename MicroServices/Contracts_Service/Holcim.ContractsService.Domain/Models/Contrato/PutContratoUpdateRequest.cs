using Holcim.ContractsService.Domain.Entities.Contratos;

namespace Holcim.ContractsService.Domain.Models.Contrato
{
    public class PutContratoUpdateRequest
    {
        public Guid IdContrato { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public Guid ProveedorId { get; set; }
        public Guid RegionId { get; set; }
        public Guid PaisId { get; set; }
        public int Monto { get; set; }
        public Guid MonedaId { get; set; }
        public Guid TipoContratoId { get; set; }
        public Guid EstadoId { get; set; }

    }
}
