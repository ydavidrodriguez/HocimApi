using Holcim.TaskSend.Domian.Models.Email;

namespace Holcim.TaskSend.Application.DataBase.Email.Commands.Create
{
    public interface ICreateEmailCommandHandler
    {
        Task<object> Execute(CreateEmailRequest createEmailRequest);
    }
}
