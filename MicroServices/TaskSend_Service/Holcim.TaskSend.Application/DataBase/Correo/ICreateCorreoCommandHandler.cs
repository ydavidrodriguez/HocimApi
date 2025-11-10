using Holcim.TaskSend.Domian.Models.Email;

namespace Holcim.TaskSend.Application.DataBase.Correo
{
    public interface ICreateCorreoCommandHandler
    {
        Task<object> Execute(CreateEmailRequest createEmailRequest);
    }
}
