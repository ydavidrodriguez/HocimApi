namespace Holcim.Application.DataBase.Region.Commands.ListById
{
    public interface IGetListRegionByIdCommandHandler
    {
        Task<Domain.Entities.Region.Region> Execute(Guid IdRegion);
    }
}
