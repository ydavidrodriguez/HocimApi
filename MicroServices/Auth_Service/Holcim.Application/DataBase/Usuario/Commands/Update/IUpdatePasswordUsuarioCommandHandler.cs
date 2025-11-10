using Holcim.Domain.Models.Usuario;

namespace Holcim.Application.DataBase.Usuario.Commands.Update
{
    public interface IUpdatePasswordUsuarioCommandHandler
    {
        Task<object> Execute(UpdatePasswordUsuario updatePasswordUsuario);
    }
}
