using Holcim.Domain.Models.Rol;
using Holcim.Domain.Models.Usuario;

namespace Holcim.Application.DataBase.Rol.Commands.Create
{
    public interface ICreateRolCommandHandler
    {
        Task<CreateRolRequest> Execute(CreateRolRequest createRolRequest);
    }
}
