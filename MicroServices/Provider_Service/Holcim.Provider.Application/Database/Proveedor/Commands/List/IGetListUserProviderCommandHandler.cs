namespace Holcim.Provider.Application.Database.Proveedor.Commands.List
{
    public interface IGetListUserProviderCommandHandler
    {
        object Execute(Guid ProveedorId);
    }
}
