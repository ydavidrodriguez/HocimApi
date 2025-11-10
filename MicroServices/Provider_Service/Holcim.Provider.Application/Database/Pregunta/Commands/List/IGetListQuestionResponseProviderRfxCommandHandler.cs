namespace Holcim.Provider.Application.Database.Pregunta.Commands.List
{
    public interface IGetListQuestionResponseProviderRfxCommandHandler
    {
         Task<object> Execute(Guid rfxid);
    }
}
