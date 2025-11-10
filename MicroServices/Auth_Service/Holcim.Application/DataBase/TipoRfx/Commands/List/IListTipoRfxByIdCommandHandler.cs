namespace Holcim.Application.DataBase.TipoRfx.Commands.List
{
    public interface IListTipoRfxByIdCommandHandler
    {
        Task<object> Execute(Guid Id);
    }
}
