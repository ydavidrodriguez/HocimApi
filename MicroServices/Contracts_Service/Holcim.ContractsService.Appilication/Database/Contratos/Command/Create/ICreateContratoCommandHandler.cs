using Holcim.ContractsService.Domain.Models;

namespace Holcim.ContractsService.Appilication.Database.Contratos.Command.Create
{
    public interface ICreateContratoCommandHandler
    {
        Task<object> Execute(PostCreateContratoRequest postCreateContratoRequest);
    }
}
