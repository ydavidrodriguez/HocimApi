using Holcim.Domain.Models.Psc;
using System.Collections.Generic;

namespace Holcim.Application.DataBase.Psc.Commands.Create
{
    public interface ICreatePscCommandHandler
    {
        Task<object> Execute(List<CreatePscRequest> CreatePscRequest);
    }
}
