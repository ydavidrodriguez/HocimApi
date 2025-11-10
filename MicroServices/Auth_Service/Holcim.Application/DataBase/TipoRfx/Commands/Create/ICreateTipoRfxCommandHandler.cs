using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.TipoRfx.Commands.Create
{
    public interface ICreateTipoRfxCommandHandler
    {
        Task<object> Execute(CreateTipoRfxRequest CreateTipoRfxRequest);
    }
}
