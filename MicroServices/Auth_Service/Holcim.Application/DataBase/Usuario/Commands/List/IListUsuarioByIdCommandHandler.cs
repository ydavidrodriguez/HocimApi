namespace Holcim.Application.DataBase.Usuario.Commands.List
{
    public interface IListUsuarioByIdCommandHandler
    {
        object Execute(Guid idUser);

    }
}
