using Holcim.Domain.Entities.Item;

namespace Holcim.Application.DataBase.Item.Commands.Update
{
    public interface IUpdateItemCommandHandler
    {
        Task<object> Execute(ItemDetalle itemdetalle);
    }
}
