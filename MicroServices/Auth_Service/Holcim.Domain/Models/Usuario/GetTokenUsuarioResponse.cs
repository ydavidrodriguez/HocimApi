namespace Holcim.Domain.Models.Usuario
{
    public class GetTokenUsuarioResponse
    {
        public Guid IdUsuario { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Idioma { get; set; } = string.Empty;


    }
}
