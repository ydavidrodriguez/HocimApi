namespace Holcim.Application.DataBase.Proveedor.Commands.GetById
{
    public interface IProveedorGetByIdCommandHandler
    {
        Task<object> Execute(Guid IdProveedor);
    }
}
