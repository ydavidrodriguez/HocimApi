using Holcim.Domain.Models.UnidadMedida;

namespace Holcim.Application.DataBase.UnidadMedida.Commands.Update
{
    public interface IUpdateUnidadMedidaCommandHandler
    {
        Task<object> Execute(UpdateUnidadMedidaRequest updateUnidadMedidaRequest);
    }
}
