public class PostUpdateConfiguracionRequest
{
    public Guid SubastaId { get; set; }
    public bool MostrarMejorOferta { get; set; }
    public bool MostrarPosicion { get; set; }
    public bool MejorarPropiaPosicion { get; set; }
    public int? PosicionAMejorar { get; set; }
}