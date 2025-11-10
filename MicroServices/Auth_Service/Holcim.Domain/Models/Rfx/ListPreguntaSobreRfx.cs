using Holcim.Domain.Entities.PreguntaArchivo;

namespace Holcim.Domain.Models.Rfx
{
    public class ListPreguntaSobreRfx
    {
        public Guid IdArchivo { get; set; }
        public string? NombreArchivo { get; set; }

        public List<PreguntaArchivo> PreguntaArchivo { get; set; }
       


    }
}
