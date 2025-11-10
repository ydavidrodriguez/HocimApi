using Holcim.Domain.Models.Psc;

namespace Holcim.Application.DataBase.Psc.Commands.Create
{
    public interface ICreatePscCommandHandler
    {
        Task<object> Execute(CreatePscRequest CreatePscRequest);
    }
}
