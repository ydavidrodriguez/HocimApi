namespace Holcim.Application.DataBase.Moneda.Commands.List
{
    public interface IListMonedaCommandHandler
    {
        Task<object> Execute(string? nombre, string codigo);
    }
}
