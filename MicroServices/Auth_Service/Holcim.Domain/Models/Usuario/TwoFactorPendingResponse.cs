namespace Holcim.Domain.Models.Usuario
{
    public class TwoFactorPendingResponse
    {
        public Guid IdUsuario { get; set; }
        public string Correo { get; set; } = string.Empty;
        public DateTime ExpiraEn { get; set; }
    }
}
