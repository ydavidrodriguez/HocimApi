namespace Holcim.Application.DataBase.Informe.Commands.List
{
    public interface IListInformesCommandHandler
    {
        Task<object> Execute(string? Nombre);
    }
}
