namespace Holcim.Application.DataBase.Encargados.Commands.Create
{
    public interface ICreateEncargadosCommandHandler
    {
        Task<object> Execute(List<Guid> encargados, Guid rfxId);
    }
}
