namespace Holcim.ContractsService.Appilication.Database.Contratos.Command.Update
{
    public interface IUpdateStateContratoCommandHandler
    {
        Task<object> Execute(Guid Estadoid, Guid IdContrato);
    }
}
