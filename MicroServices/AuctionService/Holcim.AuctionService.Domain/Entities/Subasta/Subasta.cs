namespace Holcim.AuctionService.Domain.Entities.Subasta
{
    public class Subasta
    {
        public Guid IdSubasta { get; set; }
        public int CodigoSubasta { get; set; }
        public TipoSubasta TipoSubasta { get; set; }
        public Guid TipoSubastaId { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal ValorEstimado { get; set; }
        public decimal? PrecioReferencia { get; set; }
        public decimal MejorOferta { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public Guid? RfxId { get; set; }
        public Guid EstadoId { get; set; }
        public Guid? ZonaHorariaId { get; set; }
        public Guid? UsuarioCreacionId { get; set; }
        public Guid MonedaId { get; set; }
        public bool Directo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaPausa { get; set; }

        public string? PathSubasta { get; set; }
        public bool Prueba { get; set; }

    }
}
