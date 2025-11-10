namespace Holcim.Application.DataBase.Pais.Commands.Create
{
    public interface ICreateRfxPaisCommandHandler
    {
        Task<object> Execute(IEnumerable<Guid> paises, Guid rfxId);
    }
}
