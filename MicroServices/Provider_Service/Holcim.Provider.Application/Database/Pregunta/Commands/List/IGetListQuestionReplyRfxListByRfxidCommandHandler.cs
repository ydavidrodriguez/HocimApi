namespace Holcim.Provider.Application.Database.Pregunta.Commands.List
{
    public interface IGetListQuestionReplyRfxListByRfxidCommandHandler
    {
        Task<object> Execute(Guid rfxid);
    }
}
