using Dapper;

namespace Holcim.ContractsService.Appilication.External
{
    public interface IDapperProcedure
    {
        string GetQuery(object parameters, string spname);

        string UpdateQuery(object parameters, string spname);

        string OutputQuery(DynamicParameters parameters, string spname, string parametersOutput);

    }
}
