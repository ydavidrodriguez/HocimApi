namespace Holcim.ContractsService.Domain.Models
{
    public class PasosFlujoRequest
    {
        public long Maximo { get; set; }
        public long Minimo { get; set; }
        public Guid TipoMonedaId { get; set; }
        public int Order { get; set; }
        public List<Guid> PerfilId { get; set; }
        public List<Guid> TipoContrato { get; set; }

    }
}
