using Holcim.ContractsService.Domain.Models;

namespace Holcim.ContractsService.Appilication.Database.FlujoAprobacion.Command.Create
{
    public interface ICreateFlujoAprobacionCommandHandler
    {
        Task<object> Execute(CreateFlujoAprobacionRequest createFlujoAprobacionRequest);
    }
}
