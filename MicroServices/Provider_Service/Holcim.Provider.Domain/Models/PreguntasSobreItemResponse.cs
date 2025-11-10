namespace Holcim.Provider.Domain.Models
{
    public class PreguntasSobreItemResponse
    {
        public List<PreguntaItemResponse> PreguntaItemResponse { get; set; }
        public List<PreguntaResponseSobreArchivo> ListPreguntaResponseSobreArchivo { get; set; }
    }
}
