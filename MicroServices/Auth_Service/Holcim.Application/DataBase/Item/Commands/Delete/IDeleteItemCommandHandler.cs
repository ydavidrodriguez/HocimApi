namespace Holcim.Application.DataBase.Item.Commands.Delete
{
    public interface IDeleteItemCommandHandler
    {
        Task<object> Execute(List<Domain.Entities.Item.Item> Item);
    }
}
