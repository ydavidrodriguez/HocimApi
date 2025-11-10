using Holcim.Domain.Models.Menu;

namespace Holcim.Application.DataBase.Menu.Commands.Update
{
    public interface IUpdateMenuCommandHandler
    {
        Task<UpdateMenuRequest> Execute(UpdateMenuRequest updateMenuRequest);
    }
}
