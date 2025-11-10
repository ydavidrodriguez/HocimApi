namespace Holcim.Domain.Models.Rfx
{
    public class UpdateItemRequest
    {
        public Guid? IdItem { get; set; }
        public string Nombre { get; set; }
        public Guid PscId { get; set; }
        public Guid UnidadMedidaId { get; set; }
        public int Cantidad { get; set; }
        public int? ValorUnidad { get; set; }
        public string? Observacion { get; set; }
        public bool? VisualizacionPrecioProveedor { get; set; }
        public int? Index { get; set; }

    }
}
