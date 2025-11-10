namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public interface  IGetListAdjudicarProveedorRfxCommandHandler
    {
        Task<object> Execute(Guid IdrFX);

    }
}
