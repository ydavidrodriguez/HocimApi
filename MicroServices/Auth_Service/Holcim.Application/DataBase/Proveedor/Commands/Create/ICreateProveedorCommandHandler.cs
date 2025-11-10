using Holcim.Domain.Models.Proveedor;

namespace Holcim.Application.DataBase.Proveedor.Commands.Create
{
    public interface ICreateProveedorCommandHandler
    {
        Task<object> Execute(CreatProveedorRequest creatProveedorRequest);
    }
}
