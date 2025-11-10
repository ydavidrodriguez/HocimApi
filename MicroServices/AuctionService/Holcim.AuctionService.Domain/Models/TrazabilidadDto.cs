public class TrazabilidadDto
{
    public Guid IdTrazabilidadSubasta { get; set; }
    public Guid UsuarioId { get; set; }
    public string? UsuarioNombre { get; set; }
    public string? EstadoNombre { get; set; }
    public Guid EstadoId { get; set; }
    public DateTime FechaCambio { get; set; }
    public Guid SubastaId { get; set; }
    public string? MotivoEstado { get; set; }
    public string? Email { get; set; }
}