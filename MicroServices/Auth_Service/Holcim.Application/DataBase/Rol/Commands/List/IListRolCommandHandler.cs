namespace Holcim.Application.DataBase.Rol.Commands.List
{
    public interface IListRolCommandHandler
    {
        Task<object> Execute(Guid? RolId);
    }
}
