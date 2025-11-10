namespace Holcim.Application.DataBase.Item.Commands.List
{
    public interface IListItemCommandHandler
    {
        Task<object> Execute(Guid IdItem);
    }
}
