namespace Holcim.Application.DataBase.UnidadMedida.Commands.List
{
    public interface IListUnidadMedidaCommandHandler
    {
        Task<object> Execute(string? UdmCode);
    }
}
