namespace Holcim.Application.DataBase.Menu.Commands.List
{
    public interface IListMenuCommandHandler
    {
        Task<List<Domain.Entities.Menu.Menu>> Execute();
    }
}
