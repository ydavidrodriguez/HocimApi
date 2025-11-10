using Dapper;
using Holcim.Provider.Application.External;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace Holcim.Provider.Persistence.Dapper
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

            string connectionString = Conexion();

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

            string connectionString = Conexion();

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

            string connectionString = Conexion();

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                // Example of calling a stored procedure with parameters using Dapper
                dbConnection.Execute(spname, parameters, commandType: CommandType.StoredProcedure);

                var resultado = parameters.Get<dynamic>(parametersOutput);
                string newresult = JsonConvert.SerializeObject(resultado);

                return newresult;
            }


        }

        public string Conexion() 
        {
            string server = _configuration["ConnectionStrings:DB_SERVER"];
            string port = _configuration["ConnectionStrings:DB_PORT"];
            string database = _configuration["ConnectionStrings:DB_NAME"];
            string user = _configuration["ConnectionStrings:DB_USER"];
            string password = _configuration["ConnectionStrings:DB_PASSWORD"];
            string Certificate = _configuration["ConnectionStrings:DB_CERIFICATE"];

            string connectionString = $"Server={server},{port};Database={database};Uid={user};Password={password};Trusted_Connection=false;MultipleActiveResultSets=true;TrustServerCertificate={Certificate}";

            return connectionString;


        }


    }
}
