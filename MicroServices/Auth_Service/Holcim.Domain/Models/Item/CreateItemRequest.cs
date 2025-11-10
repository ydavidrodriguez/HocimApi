using Holcim.Domain.Models.Pregunta;

namespace Holcim.Domain.Models.Item
{
    public class CreateItemRequest
    {
        public string Nombre { get; set; }
        public int? Index { get; set; }
        public Guid? PscId { get; set; }
        public Guid UnidadMedidaId { get; set; }
        public int Cantidad { get; set; }
        public int? ValorUnidad { get; set; }
        public string? Observacion { get; set; }
        public bool? VisualizacionPrecioProveedor { get; set; }
        public Guid? MonedaId { get; set; }

    }
}
