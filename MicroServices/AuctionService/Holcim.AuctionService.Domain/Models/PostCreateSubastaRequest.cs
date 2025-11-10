namespace Holcim.AuctionService.Domain.Models
{
    public class PostCreateSubastaRequest
    {
        public Guid TipoSubastaId { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal? ValorEstimado { get; set; }
        public decimal PrecioReferencia { get; set; }
        public decimal? MejorOferta  { get; set; }
        public Guid? TipoOfertaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public Guid? RfxId { get; set; }
        public Guid? EstadoId { get; set; }
        public Guid? ZonaHorariaId {get; set;}
        public Guid? UsuarioCreacionId {get; set;}
        public List<string>? proveedoresInvitados {get; set;}
        public List<Guid>? GRUs {get; set;}
        public List<PostListItemsRequest>? postListItemsRequests { get; set; }
        public bool Directo { get; set; }
        public Guid MonedaId { get; set; }
        public bool? Prueba { get; set; }

        public Guid? IdSubasta { get; set; }
    }
}
