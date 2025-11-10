using Holcim.ContractsService.Domain.Models.Contrato;

namespace Holcim.ContractsService.Appilication.Database.Contratos.Command.Update
{
    public interface IUpdateContratoCommandHandler
    {
         Task<object> Execute(PutContratoUpdateRequest putContratoUpdateRequest);
    }
}
