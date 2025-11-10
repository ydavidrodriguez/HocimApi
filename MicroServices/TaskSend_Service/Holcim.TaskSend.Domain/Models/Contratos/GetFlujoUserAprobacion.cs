namespace Holcim.TaskSend.Domain.Models.Contratos
{
    public class GetFlujoUserAprobacion
    {
        public Guid IdFlujoContrato { get; set; }
        public Guid FlujoAprobacionId { get; set; }
        public Guid ContratoId { get; set; }
        public Guid PerfilId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Descripcion { get; set; }
        public Guid IdContrato { get; set; }
        public Guid IdFlujoAprobacion { get; set; }
        public string FlujoAprobacionNombre { get; set; }
        public Guid IdPasoFlujo { get; set; }

    }
}
