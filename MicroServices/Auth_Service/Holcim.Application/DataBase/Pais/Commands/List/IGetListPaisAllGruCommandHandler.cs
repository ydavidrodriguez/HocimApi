namespace Holcim.Application.DataBase.Pais.Commands.List
{
    public interface IGetListPaisAllGruCommandHandler
    {
        Task<object> Execute(string? leng);
    }
}
