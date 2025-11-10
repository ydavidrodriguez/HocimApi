using Holcim.Domain.Models.Proveedor;
using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.Rfx.Commands.Create
{
    public interface IPostCreateAdjudicarRfxCommandHandler
    {
        Task<object> Execute(List<PostCreateProveedorAdjudicar> ListPostCreateProveedorAdjudicar);
    }
}
