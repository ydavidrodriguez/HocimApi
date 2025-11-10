namespace Holcim.Application.DataBase.Psc.Commands.List
{
    public interface IGetListPscCommandHandler
    {
        Task<object> Execute(string? Codigo);

    }
}
