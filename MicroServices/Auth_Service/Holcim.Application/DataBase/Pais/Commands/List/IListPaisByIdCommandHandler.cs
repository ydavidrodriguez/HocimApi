namespace Holcim.Application.DataBase.Pais.Commands.List
{
    public interface IListPaisByIdCommandHandler
    {
        Task<object> Execute(Guid PaisId);

    }
}
