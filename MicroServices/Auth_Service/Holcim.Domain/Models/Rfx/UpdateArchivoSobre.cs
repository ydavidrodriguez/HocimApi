using Holcim.Domain.Models.Pregunta;

namespace Holcim.Domain.Models.Rfx
{
    public class UpdateArchivoSobre
    {
        public Guid? IdArchivoSobre { get; set; }
        public string? NombreSobre { get; set; }
        public List<CrearPregunta> CrearPregunta { get; set; }


    }
}
