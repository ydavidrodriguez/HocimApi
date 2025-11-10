namespace Holcim.AuctionService.Domain.Models.Subasta
{
    public class GetListAuctionAllResponse
    {
        public Guid IdSubasta { get; set; }
        public int CodigoSubasta {get; set;}
        public string? Titulo { get; set; }
        public DateTime FechaInicio { get; set; }
        public string? NombreEstado { get; set; }
        public string? NombreRfx { get; set; }
        public Guid? IdRfx { get; set; }
        public Guid? IdUsuario { get; set; }
        public string? NombreCompleto { get; set; }
        public Guid IdTipoSubasta { get; set; }
        public string? NombreSubasta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Prueba { get; set;}

    }
}
