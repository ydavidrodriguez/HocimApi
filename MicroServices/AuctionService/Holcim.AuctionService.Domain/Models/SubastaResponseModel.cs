public class SubastaDto
{
    public Guid IdSubasta { get; set; }
    public Guid TipoSubastaId { get; set; }
    public string? TipoSubastaName { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public decimal ValorEstimado { get; set; }
    public decimal PrecioReferencia { get; set; }
    public Guid? TipoPreciosId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public Guid? RfxId { get; set; }
    public string? RfxName { get; set; }
    public Guid EstadoId { get; set; }
    public string? EstadoName { get; set; }
    public List<Guid>? Regiones { get; set; }
    public List<string>? proveedoresInvitados { get; set; }
    public List<Guid>? Proveedores { get; set; }
    public List<ItemDto>? Items { get; set; }
    public Guid? ZonaHorariaId { get; set; }
    public string? ZonaHorariaName { get; set; }
    public Guid? UsuarioCreacionId { get; set; }
    public string? UsuarioCreacionName { get; set; }

}