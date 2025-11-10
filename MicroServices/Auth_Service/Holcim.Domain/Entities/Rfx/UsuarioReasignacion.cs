using Holcim.Domain.Entities.Motivos;

namespace Holcim.Domain.Entities.Rfx
{
    public class UsuarioReasignacion
    {
        public Guid IdUsuarioReasignacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public Rfx Rfx { get; set; }
        public Guid RfxId { get; set; }
        public string? Usuarios { get; set; }
        public bool Estado { get; set; }   
        public Guid UsuarioOld { get; set; }   
        public Motivo Motivo { get; set; }   
        public Guid MotivoId { get; set; }   

    }
}
