namespace Holcim.Application.DataBase.Region.Commands.List
{
    public interface IGetListRegionCommandHandler
    {
        Task<List<Domain.Entities.Region.Region>> Execute(string? Nombre);

    }
}
