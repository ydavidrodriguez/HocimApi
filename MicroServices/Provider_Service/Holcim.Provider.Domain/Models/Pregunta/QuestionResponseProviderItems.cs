namespace Holcim.Provider.Domain.Models.Pregunta
{
    public class QuestionResponseProviderItems
    {
        public Guid IdItem { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Respuesta { get; set; }
        public string UrlArchivo { get; set; }
        public long Total { get; set; }
        public int ValorUnidad { get; set; }
        public long ValorReferencia { get; set; }
        public int? Index { get; set; }

    }
}
