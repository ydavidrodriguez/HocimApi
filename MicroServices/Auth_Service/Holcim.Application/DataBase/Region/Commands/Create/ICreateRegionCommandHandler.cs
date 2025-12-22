using Holcim.Domain.Models.Region;
using System.Collections.Generic;

namespace Holcim.Application.DataBase.Region.Commands.Create
{
    public interface ICreateRegionCommandHandler
    {
        Task<object> Execute(List<CreateRegionRequest> CreateRegionRequest);
    }
}
