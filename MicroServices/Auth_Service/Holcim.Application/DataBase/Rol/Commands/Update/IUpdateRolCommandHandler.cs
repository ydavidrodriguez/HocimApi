using Holcim.Domain.Models.Rol;

namespace Holcim.Application.DataBase.Rol.Commands.Update
{
    public interface IUpdateRolCommandHandler
    {
        Task<UpdateRolRequest> Execute(UpdateRolRequest UpdateRolRequest);
    }
}
