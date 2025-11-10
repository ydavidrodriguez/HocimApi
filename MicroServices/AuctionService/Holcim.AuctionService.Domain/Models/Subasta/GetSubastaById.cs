using Holcim.AuctionService.Domain.Models.Items;
using Holcim.AuctionService.Domain.Models.Region;

namespace Holcim.AuctionService.Domain.Models.Subasta
{
    public class GetSubastaById
    {
        public Guid IdSubasta { get; set; }
        public int CodigoSubasta { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioReferencia { get; set; }
        public decimal MejorOferta  { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool Directo { get; set; }
        public Guid IdMoneda { get; set; }
        public string NombreMoneda { get; set; }
        public string MonedaDescripcion { get; set; }
        public Guid IdTipoSubasta { get; set; } 
        public string? DescripcionSubasta { get; set; }
        public Guid IdEstado { get; set; }
        public string? Nombre { get; set; }
        public Guid IdZonaHoraria { get; set; }
        public string? NombreZonaHoraria { get; set; }
        public Guid IdTipoOferta { get; set; }
        public string? NombreTipoOferta { get; set; }
        public Guid? IdRfx { get; set; }
        public string? NombreRfx { get; set; }
        public Guid IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public int TipoSubasta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<GetPaisResponse>? GetPaisResponseList { get; set; }
        public List<GetItemsSubasta>? GetItemsSubasta { get; set; }
        public List<GetProveedorResponse>? GetProveedorResponse { get; set; }
        public List<Guid>? Colaboradores { get; set; } = new List<Guid>();
        public bool Prueba { get; set; }
        public object ConfiguracionSubasta { get; set; }
        public DateTime? FechaPausa { get; set; }

        public string? PathSubasta { get; set; }    

    }
}
