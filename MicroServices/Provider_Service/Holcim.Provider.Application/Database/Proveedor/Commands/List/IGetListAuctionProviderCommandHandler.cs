namespace Holcim.Provider.Application.Database.Proveedor.Commands.List
{
    public interface IGetListAuctionProviderCommandHandler
    {
        object Execute(Guid UsuarioId);
    }
}
