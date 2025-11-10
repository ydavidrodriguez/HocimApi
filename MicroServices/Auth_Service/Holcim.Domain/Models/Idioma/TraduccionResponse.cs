namespace Holcim.Domain.Models.Idioma
{
    public class TraduccionResponse
    {
        public string idiomaOrigen { get; set; } = string.Empty;
        public string idiomaDestino { get; set; } = string.Empty;
        public string textoOriginal { get; set; } = string.Empty;
        public string textoTraducido { get; set; } = string.Empty;

    }
}
