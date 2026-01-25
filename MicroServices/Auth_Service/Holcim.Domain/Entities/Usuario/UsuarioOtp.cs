namespace Holcim.Domain.Entities.Usuario
{
    public class UsuarioOtp
    {
        public Guid IdUsuarioOtp { get; set; }
        public Guid UsuarioId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public bool Usado { get; set; }
    }
}
