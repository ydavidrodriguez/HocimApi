namespace Holcim.Application.DataBase.UnidadMedida.Commands.GetById
{
    public interface IUnidadMedidaGetByIdCommandHandler
    {
        Task<object> Execute(Guid IdUnidadMedida);
    }
}
