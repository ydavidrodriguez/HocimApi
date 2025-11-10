namespace Holcim.TaskSend.Application.DataBase.Email.Commands.SendEmail
{
    public interface ISendEmailCommandHandler
    {
        Task<object> Execute();
    }
}
