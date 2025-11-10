using Holcim.TaskSend.Domian.Models.Email;

namespace Holcim.TaskSend.Application.External.Smtp
{
    public interface ISmtpCommandHandler
    {
        Task<object> Execute(CreateEmailRequest createEmailRequest);
    }
}
