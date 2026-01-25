using Holcim.Domain.Models.UnidadMedida;

namespace Holcim.Application.DataBase.UnidadMedida.Commands.Create
{
    public interface ICreateUnidadMedidaCommandHandler
    {
        Task<object> Execute(List<CreateUnidadMedidaRequest> createUnidadMedidaRequest);
    }
}
