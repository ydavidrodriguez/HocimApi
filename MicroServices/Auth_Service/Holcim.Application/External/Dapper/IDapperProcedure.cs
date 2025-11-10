using Dapper;

namespace Holcim.Application.External.Dapper
{
    public interface IDapperProcedure
    {
        string GetQuery(object parameters, string spname);

        string UpdateQuery(object parameters, string spname);

        string OutputQuery(DynamicParameters parameters, string spname, string parametersOutput);
    }
}
