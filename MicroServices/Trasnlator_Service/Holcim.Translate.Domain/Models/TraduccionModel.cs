namespace Holcim.Translate.Domain.Models
{
    public class TraduccionModel
    {
        public string IdiomaOrigen { get; set; } = string.Empty;
        public string IdiomaDestino { get; set; } = string.Empty;
        public string TextoOriginal { get; set; } = string.Empty;
        public string TextoTraducido { get; set; } = string.Empty; 

    }
}
