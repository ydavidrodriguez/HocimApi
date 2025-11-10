namespace Holcim.Application.DataBase.Proveedor.Commands.List
{
    public interface IListPaisByZonaHorariaByIdCommandHandler
    {

        Task<object> Execute(Guid PaisId);

    }
}
