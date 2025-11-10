using Holcim.Domain.Models.Proveedor;

namespace Holcim.Application.DataBase.Rfx.Commands.Create
{
    public interface IPostDeleteAdjudicarProveedorCommandHandler
    {
        Task<object> Execute(PostDeleteProveedorAdjudicar postDeleteProveedorAdjudicar);
    }
}
