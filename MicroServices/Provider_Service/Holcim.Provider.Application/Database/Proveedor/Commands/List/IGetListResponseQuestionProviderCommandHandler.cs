namespace Holcim.Provider.Application.Database.Proveedor.Commands.List
{
    public interface IGetListResponseQuestionProviderCommandHandler
    {
        Task<object> Execute(Guid ProveedorId, Guid Rfxid);
    }
}
