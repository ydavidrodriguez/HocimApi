using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.Rfx.Commands.Update
{
    public interface IUpdateStateRfxCommandHandler
    {
        Task<object> Execute(RfxTrazabilidadRequest rfxTrazabilidadRequest);
    }
}
