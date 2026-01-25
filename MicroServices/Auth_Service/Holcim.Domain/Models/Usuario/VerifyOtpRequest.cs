namespace Holcim.Domain.Models.Usuario
{
    public class VerifyOtpRequest
    {
        public string Correo { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
    }
}
