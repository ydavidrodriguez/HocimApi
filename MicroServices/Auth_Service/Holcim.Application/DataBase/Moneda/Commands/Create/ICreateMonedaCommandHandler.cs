using Holcim.Domain.Models.Moneda;

namespace Holcim.Application.DataBase.Moneda.Commands.Create
{
    public interface ICreateMonedaCommandHandler
    {
        Task<object> Execute(CreateMonedaRequest createMonedaRequest);
        
    }
}
