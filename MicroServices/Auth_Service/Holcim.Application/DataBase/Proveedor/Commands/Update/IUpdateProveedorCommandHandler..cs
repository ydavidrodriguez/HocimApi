using Holcim.Domain.Models.Proveedor;

namespace Holcim.Application.DataBase.Proveedor.Commands.Update
{
    public interface IUpdateProveedorCommandHandler
    {
        Task<object> Execute(UpdateProveedorRequest updateProveedorRequest, bool Directo);
    }
}
