using Holcim.Domain.Models.Region;

namespace Holcim.Application.DataBase.Region.Commands.Create
{
    public interface ICreateRegionCommandHandler
    {
        Task<CreateRegionRequest> Execute(CreateRegionRequest CreateRegionRequest);
    }
}
