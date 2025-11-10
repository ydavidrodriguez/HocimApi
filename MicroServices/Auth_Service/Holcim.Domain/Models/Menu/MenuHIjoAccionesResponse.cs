using Holcim.Domain.Entities.Acciones;

namespace Holcim.Domain.Models.Menu
{
    public class MenuHIjoAccionesResponse
    {
        public Guid IdMenu { get; set; }
        public string Nombre { get; set; }
        public string PathFront { get; set; }
        public Guid? IdPadre { get; set; }
        public bool Estado { get; set; }
        public List<Acciones> ListAcciones { get; set; }


    }
}
