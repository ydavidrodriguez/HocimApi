using Holcim.Domain.Models.Usuario;

namespace Holcim.Application.DataBase.Usuario.Commands.List
{
    public interface IGetUsuarioMenuByEmail
    {
        Task<object> Execute(Guid Idusuario);
    }
}
