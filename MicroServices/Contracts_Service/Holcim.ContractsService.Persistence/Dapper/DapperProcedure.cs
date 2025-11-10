using Dapper;
using Holcim.ContractsService.Appilication.External;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;

namespace Holcim.ContractsService.Persistence.Dapper
{
    public class DapperProcedure : IDapperProcedure
    {

        private readonly IConfiguration _configuration;

        public DapperProcedure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetQuery(object parameters, string spname)
        {

            string connectionString = _configuration["sqlconnectionstrings"].ToString();

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                // Example of calling a stored procedure with parameters using Dapper
                object result = dbConnection.Query<object>(spname, parameters, commandType: CommandType.StoredProcedure);
                string newresult = JsonConvert.SerializeObject(result);

                return newresult;
            }


        }

        public string UpdateQuery(object parameters, string spname)
        {

            string connectionString = _configuration["sqlconnectionstrings"].ToString();

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                // Example of calling a stored procedure with parameters using Dapper
                object result = dbConnection.Execute(spname, parameters, commandType: CommandType.StoredProcedure);
                string newresult = JsonConvert.SerializeObject(result);

                return newresult;
            }


        }

        public string OutputQuery(DynamicParameters parameters, string spname, string parametersOutput)
        {

            string connectionString = _configuration["sqlconnectionstrings"].ToString();

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                // Example of calling a stored procedure with parameters using Dapper
                dbConnection.Execute(spname, parameters, commandType: CommandType.StoredProcedure);

                var resultado = parameters.Get<dynamic>(parametersOutput);
                string newresult = JsonConvert.SerializeObject(resultado);

                return newresult;
            }


        }



    }
}
