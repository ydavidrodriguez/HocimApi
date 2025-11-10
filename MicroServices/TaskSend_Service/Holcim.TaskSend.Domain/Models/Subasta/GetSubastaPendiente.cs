namespace Holcim.TaskSend.Domain.Models.Subasta
{
    public class GetSubastaPendiente
    {
        public Guid IdSubasta { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

    }
}
