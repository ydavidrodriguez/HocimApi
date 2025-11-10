namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public interface IGetListRfxByUserCommandHandler
    {
        Task<object> Execute(Guid IdUsuario);
    }
}
