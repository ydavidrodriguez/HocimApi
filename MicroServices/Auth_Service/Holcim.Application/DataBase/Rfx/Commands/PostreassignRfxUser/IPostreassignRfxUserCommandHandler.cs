using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.Rfx.Commands.PostreassignRfxUser
{
    public interface IPostreassignRfxUserCommandHandler
    {
        Task<object> Execute(PostreassignRfxUserRequest postreassignRfxUserRequest);
    }
}
