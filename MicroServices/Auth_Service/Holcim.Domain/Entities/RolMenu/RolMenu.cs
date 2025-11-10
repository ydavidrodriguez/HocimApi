namespace Holcim.Domain.Entities.RolMenu
{
    public class RolMenu
    {
        public Guid RolMenuId { get; set; }
        public Guid RolId { get; set; }
        public Rol.Rol Rol { get; set; }
        public Guid MenuId { get; set; }
        public Menu.Menu Menu { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }


    }
}
