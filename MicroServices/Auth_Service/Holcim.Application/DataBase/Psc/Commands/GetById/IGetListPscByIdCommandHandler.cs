namespace Holcim.Application.DataBase.Psc.Commands.GetById
{
    public interface IGetListPscByIdCommandHandler
    {
        Task<object> Execute(Guid IdPsc);
    }
}
