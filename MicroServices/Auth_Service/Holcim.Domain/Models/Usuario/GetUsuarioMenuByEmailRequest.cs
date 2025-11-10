using Holcim.Domain.Models.Menu;

namespace Holcim.Domain.Models.Usuario
{
    public class GetUsuarioMenuByEmailRequest
    {
        public Guid IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public Guid IdMenuRol { get; set; }
        public Guid MenuId { get; set; }
        public Entities.Menu.Menu Menu { get; set; }
        public Guid RolId { get; set; }
        public Entities.Rol.Rol Rol { get; set; }
        public List<MenuHIjoAccionesResponse> Hijos { get; set; }
        public bool PrimerIngreso { get; set; }
        public int? Posicion { get; set; }

    }
}

