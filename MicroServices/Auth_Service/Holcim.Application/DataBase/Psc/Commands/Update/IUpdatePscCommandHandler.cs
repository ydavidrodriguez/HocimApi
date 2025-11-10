using Holcim.Domain.Models.Psc;

namespace Holcim.Application.DataBase.Psc.Commands.Update
{
    public interface IUpdatePscCommandHandler
    {
        Task<object> Execute(UpdatePscRequest UpdatePscRequest);
    }
}
