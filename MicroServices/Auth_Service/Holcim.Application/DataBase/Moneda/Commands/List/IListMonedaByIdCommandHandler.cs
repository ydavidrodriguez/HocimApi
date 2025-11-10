namespace Holcim.Application.DataBase.Moneda.Commands.List
{
    public interface IListMonedaByIdCommandHandler
    {
        Task<object> Execute(Guid MonedaId);
    }
}
