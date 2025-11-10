namespace Holcim.Application.DataBase.Cargo.Commands.List
{
    public interface IListCargoCommandHandler
    {
        Task<object> Execute();
    }
}
