namespace Holcim.ContractsService.Domain.Models
{
    public class PostCreateContratoRequest
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public Guid ProveedorId { get; set; }
        public Guid RegionId { get; set; }
        public Guid PaisId { get; set; }
        public long Monto { get; set; }
        public Guid MonedaId { get; set; }
        public Guid TipoContratoId { get; set; }
        public Guid? IdContrato { get; set; }

    }
}
