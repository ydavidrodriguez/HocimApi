namespace Holcim.DocumetsService.Application.DataBase.Documentos.Commands.List
{
    public interface IConsultDocumentCommandHandler
    {
        Task<object> Execute(string path);
    }
}
