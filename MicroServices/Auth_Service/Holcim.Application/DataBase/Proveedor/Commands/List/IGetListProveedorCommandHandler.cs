namespace Holcim.Application.DataBase.Proveedor.Commands.List
{
    public interface IGetListProveedorCommandHandler
    {
        Task<List<Domain.Entities.Proveedor.Proveedor>> Execute(string? nombre, string? dominio);
    }
}
