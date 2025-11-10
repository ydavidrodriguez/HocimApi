namespace Holcim.Application.DataBase.Sobre.Commands.Create
{
    public interface ICreateSobreCommandHandler
    {
        Task<object> Execute(List<Domain.Models.Pregunta.ArchivoSobre> archivoSobre, Guid rfxId);
    }
}
