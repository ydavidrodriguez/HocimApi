using Holcim.Provider.Domain.Entities;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.Update
{
    public interface IUpdateResponseQuestionProviderCommandHandler
    {
        Task<object> Execute(List<RespuestaPregunta> postRespuestaPregunta);
    }
}
