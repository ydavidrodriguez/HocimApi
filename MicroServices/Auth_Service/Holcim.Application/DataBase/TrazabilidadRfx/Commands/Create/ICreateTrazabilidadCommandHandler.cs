using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.TrazabilidadRfx.Commands.Create
{
    public interface ICreateTrazabilidadCommandHandler
    {
        Task<object> Execute(CreateRfxRequest request, Guid rfxId);
    }
}
