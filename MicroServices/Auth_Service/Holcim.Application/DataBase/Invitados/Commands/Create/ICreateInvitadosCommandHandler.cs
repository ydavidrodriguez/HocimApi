using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.Invitados.Commands.Create
{
    public interface ICreateInvitadosCommandHandler
    {
         Task<object> Execute(CreateRfxRequest request, Guid rfxId, Guid EstadoId);
    }
}
