using Holcim.Domain.Entities.Cargo;

namespace Holcim.Domain.Models.Usuario
{
    public class UsuarioFilterResponse
    {
        public Guid IdCuentaAdmin { get; set; }
        public GetUsuarioResponse Usuario { get; set; }
        public Guid CargoId { get; set; }
        public Guid? DepartamentoId { get; set; }
        public Cargo Cargo { get; set; }
        public Guid PaisId { get; set; }
        public Domain.Entities.Pais.Pais Pais { get; set; }
        public List<Domain.Entities.Rol.Rol> Rol { get; set; }
        public DateTime UltimaConexion { get; set; }

    }
}
