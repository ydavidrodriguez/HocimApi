namespace Holcim.Domain.Models.Pregunta
{
    public class ArchivoSobre
    {
        public Guid? IdArchivoSobre { get; set; }
        public string? NombreSobre { get; set; }
        public string? Detalle { get; set; }
        public List<CrearPregunta> CrearPregunta { get; set; }

    }
}

