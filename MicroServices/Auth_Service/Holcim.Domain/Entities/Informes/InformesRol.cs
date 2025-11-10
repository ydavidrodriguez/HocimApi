namespace Holcim.Domain.Entities.Informes
{
    public class InformesRol
    {
        public Guid IdInformesRol { get; set; }
        public  Informes Informes  { get; set; }
        public Guid InformesId { get; set; }
        public  Rol.Rol Rol { get; set; }
        public Guid RolId { get; set; }
    }
}
