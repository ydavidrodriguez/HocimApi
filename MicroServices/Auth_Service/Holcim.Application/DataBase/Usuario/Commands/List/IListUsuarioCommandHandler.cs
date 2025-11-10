using AutoMapper;

namespace Holcim.Application.DataBase.Usuario.Commands.List
{
    public interface IListUsuarioCommandHandler
    {
        object Execute(string? Nombre, string? Correo);
    }
}
