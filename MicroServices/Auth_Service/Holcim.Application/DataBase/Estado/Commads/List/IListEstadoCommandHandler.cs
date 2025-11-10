namespace Holcim.Application.DataBase.Estado.Commads.List
{
    public interface IListEstadoCommandHandler
    {
        Task<object> Execute(string? Nombre, string? TipoEstado, Guid? EstadoId);
    }
}
