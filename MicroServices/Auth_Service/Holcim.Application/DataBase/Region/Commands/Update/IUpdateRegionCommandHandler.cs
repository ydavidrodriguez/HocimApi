using Holcim.Domain.Models.Region;

namespace Holcim.Application.DataBase.Region.Commands.Update
{
    public interface IUpdateRegionCommandHandler
    {
        Task<UpdateRegionRequest> Execute(UpdateRegionRequest UpdateRegionRequest);
    }
}
