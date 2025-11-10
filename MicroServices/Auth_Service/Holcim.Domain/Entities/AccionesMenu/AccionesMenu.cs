namespace Holcim.Domain.Entities.AccionesMenu
{
    public class AccionesMenu
    {
        public Guid IdAccionesMenu { get; set; }
        public Guid AccionesId { get; set; }
        public Acciones.Acciones Acciones { get; set; } = new Acciones.Acciones();
        public Guid MenuId { get; set; }
        public Menu.Menu Menu { get; set; } = new Menu.Menu();
        public Guid RolId { get; set; } 
        public Rol.Rol Rol { get; set; } = new Rol.Rol();
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }


    }
}
