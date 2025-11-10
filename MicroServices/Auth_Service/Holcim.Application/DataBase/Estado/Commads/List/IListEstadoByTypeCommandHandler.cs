namespace Holcim.Application.DataBase.Estado.Commads.List
{
    public interface IListEstadoByTypeCommandHandler
    {
        Task<object> Execute(Guid TipoEstado);
    }
}
