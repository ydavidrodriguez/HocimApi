namespace Holcim.Domain.Entities.Usuario
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; }= string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public TipoUsuario.TipoUsuario TipoUsuario { get; set; }
        public Guid TipoUsuarioId { get; set; }
        public int Intentos { get; set; }
        public bool FechaBloqueo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
        public bool? Aprobador { get; set; }
        public DateTime UltimaConexion  { get; set; }
        public bool PrimerIngreso { get; set; }
        public Idioma.Idioma Idioma { get; set; }
        public Guid IdiomaId { get; set; }

    }
}
