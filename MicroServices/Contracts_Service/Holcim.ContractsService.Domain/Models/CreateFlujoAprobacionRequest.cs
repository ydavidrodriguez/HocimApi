namespace Holcim.ContractsService.Domain.Models
{
    public class CreateFlujoAprobacionRequest
    {
        public string Nombre { get; set; }
        public Guid RegionId { get; set; }
        public  List<PasosFlujoRequest> pasosFlujoRequest { get; set; }

    }
}
