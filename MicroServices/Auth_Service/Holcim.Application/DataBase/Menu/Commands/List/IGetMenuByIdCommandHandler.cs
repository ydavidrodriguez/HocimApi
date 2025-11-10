namespace Holcim.Application.DataBase.Menu.Commands.List
{
    public interface IGetMenuByIdCommandHandler
    {
        Task<object> Execute(Guid IdUsuario);

    }
}
