namespace Holcim.Domain.Entities.Usuario
{
    public class UsuarioToken
    {
        public Guid IdUsuarioToken { get; set; }
        public Guid Idusuario { get; set; }
        public string Token { get; set; } = string.Empty;   
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; } 

    }
}
