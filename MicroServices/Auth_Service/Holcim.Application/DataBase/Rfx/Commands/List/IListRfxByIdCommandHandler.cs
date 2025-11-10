namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public interface IListRfxByIdCommandHandler
    {
        Task<object> Execute(Guid Id);
    }
}
