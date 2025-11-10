namespace Holcim.Provider.Domain.Models.Pregunta
{
    public class QuestionResponseProviderRfxResponse
    {
        public RespuestaProveedorRfxIdResponse RespuestaProveedorRfxIdResponse { get; set; }
        public List<QuestionResponseProviderResponse> QuestionResponseProviderResponse { get; set; }
        public List<QuestionResponseProviderItems> QuestionResponseProviderItems { get; set; }
        

    }
}
