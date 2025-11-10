namespace Holcim.TaskSend.Domian.Models.Email
{
    public class CreateEmailRequest
    {
        public List<string>? Destinatarios { get; set; }
        public string? Remitente { get; set; }
        public string? Asunto { get; set; }
        public string? Body  { get; set; }

    }
}
