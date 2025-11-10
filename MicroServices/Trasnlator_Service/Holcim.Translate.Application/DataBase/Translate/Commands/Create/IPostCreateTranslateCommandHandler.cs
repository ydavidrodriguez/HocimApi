namespace Holcim.Translate.Application.DataBase.Translate.Commands.Create
{
    public interface IPostCreateTranslateCommandHandler
    {
        Task<object> Execute(string textoOring);
    }
}
