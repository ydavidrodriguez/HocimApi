namespace Holcim.AuctionService.Domain.Entities.Subasta
{
    public class ConfiguracionSubastaInglesa
    {
        public Guid IdConfiguracionSubasta { get; set; }
        public Guid SubastaId { get; set; }
        public bool MostrarMejorOferta { get; set; }
        public bool MostrarPosicion { get; set; }
        public bool MejorarPropiaPosicion { get; set; }
        public int? PosicionAMejorar { get; set; }
        public Subasta Subasta { get; set; }
        public string? JobIdInicio { get; set; }
        public string? JobIdFin { get; set; }
    }
}
