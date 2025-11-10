namespace Holcim.Provider.Application.Database.Proveedor.Commands.List
{
    public interface IGetPorcentResponseProviderByRfx
    {
        object Execute(Guid RfxIdRequest);
    }
}
