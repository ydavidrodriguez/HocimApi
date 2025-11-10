namespace Holcim.Application.DataBase.Pais.Commands.List
{
    public interface IListPaisCommandHandler
    {
        Task<object> Execute(string? nombre, string leng);
    }
}
