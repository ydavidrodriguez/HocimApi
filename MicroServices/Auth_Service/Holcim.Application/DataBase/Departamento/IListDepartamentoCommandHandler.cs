namespace Holcim.Application.DataBase.Departamento
{
    public interface IListDepartamentoCommandHandler
    {
        Task<List<Domain.Entities.Dependencia.Departamento>> Execute();
    }
}
