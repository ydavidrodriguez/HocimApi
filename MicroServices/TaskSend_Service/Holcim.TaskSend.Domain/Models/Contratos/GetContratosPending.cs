namespace Holcim.TaskSend.Domain.Models.Contratos
{
    public class GetContratosPending
    {
        public Guid IdContrato  { get; set; }
        public string? NombreContrato { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }
        public Guid RegionId { get; set; }
        public Guid IdTipoContrato { get; set; }
        public string? NombreTipoContrato { get; set; }

    }
}
