using Holcim.Domain.Models.Moneda;

namespace Holcim.Application.DataBase.Moneda.Commands.Update
{
    public interface IUpdateMonedaCommandHandler
    {
        Task<object> Execute(UpdateMonedaRequest UpdateMonedaRequest);
    }
}
