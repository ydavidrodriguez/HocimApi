public class ItemDto
{
    public Guid IdItem { get; set; }
    public string Nombre { get; set; }
    public bool Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActulizacion { get; set; }
    public Guid? UnidadMedidaId { get; set; }
    public Guid? PscsId { get; set; }
    public int? Cantidad { get; set; }
    public decimal? ValorUnidad { get; set; }
    public string Observacion { get; set; }
    public Guid? MonedaId { get; set; }
    public decimal? PrecioOferta { get; set; }
}