namespace Holcim.Domain.Entities.ZonaHoraria
{
    public class ZonaHorariaPais
    {
        public Guid IdZonaHorariaPais { get; set; }
        public Pais.Pais Pais { get; set; }
        public Guid PaisId { get; set; }
        public Guid ZonaHorariaId { get; set; }
        public ZonaHoraria ZonaHoraria { get; set; }
        public bool Estado { get; set; }

    }
}
