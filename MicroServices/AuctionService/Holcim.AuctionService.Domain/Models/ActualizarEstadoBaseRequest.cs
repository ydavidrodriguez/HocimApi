public  class ActualizarEstadoBaseRequest
{
    public Guid UsuarioId { get; set; }
    public Guid SubastaId { get; set; }
    public Guid EstadoId { get; set; }
    public DateTime? FechaSuspension { get; set; }
    public DateTime? FechaInicioSuspension { get; set; }
    public string? Motivo { get; set; }
    public bool? PausarChat { get; set; }
    public bool? ReanudarChat { get; set; }
}