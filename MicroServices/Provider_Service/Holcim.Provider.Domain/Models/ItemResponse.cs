namespace Holcim.Provider.Domain.Models
{
    public class ItemResponse
    {
        public Guid IdItem { get; set; }
        public string? Nombre { get; set; }
        public int valorUnidad { get; set; }
        public bool VisualizacionPrecioProveedor { get; set; }
        public long Total { get; set; }
        public string? NombreMoneda { get; set; }
        public int? Cantidad { get; set; }
        public int? Index { get; set; }

    }
}
