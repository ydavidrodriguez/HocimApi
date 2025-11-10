namespace Holcim.Domain.Models
{
    public class BaseResponseModel
    {
        public int StatusCode { get; set; }
        public bool Succes { get; set; }
        public string Message { get; set; } = string.Empty;
        public dynamic Data { get; set; }
    }
}
