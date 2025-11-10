namespace Holcim.ContractsService.Appilication.Database.Contratos.Command.GetById
{
    public interface IGetContratoByIdCommandHandler
    {
        Task<object> Execute(Guid IdContrato);
    }
}
