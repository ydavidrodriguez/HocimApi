using Holcim.Domain.Models.Usuario;

namespace Holcim.Application.DataBase.Usuario.Commands.Update
{
    public interface IUpdateUsuarioCommandHandler
    {
        Task<object> Execute(UpdateUsuarioRequest updateUsuarioRequest);
    }
}
