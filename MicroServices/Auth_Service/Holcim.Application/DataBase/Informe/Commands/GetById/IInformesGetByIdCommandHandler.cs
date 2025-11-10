namespace Holcim.Application.DataBase.Informe.Commands.GetById
{
    public interface IInformesGetByIdCommandHandler
    {
        Task<object> Execute(Guid IdInformes);
    }
}
