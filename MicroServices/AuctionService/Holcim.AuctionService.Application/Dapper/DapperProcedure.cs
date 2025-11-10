using System.Data;
using Dapper;
using Holcim.AuctionService.Application.External;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Dapper
{
    public class DapperProcedure : IDapperProcedure
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DapperProcedure> _logger;

        public DapperProcedure(IConfiguration configuration, ILogger<DapperProcedure> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }


        public string GetQuery(object parameters, string spname)
        {
            using (IDbConnection dbConnection = new SqlConnection(Conexion()))
            {
                try
                {

                    object result = dbConnection.Query<object>(spname, parameters, commandType: CommandType.StoredProcedure);
                    return JsonConvert.SerializeObject(result);

                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex, $"Error executing stored procedure {spname} with parameters {JsonConvert.SerializeObject(parameters)}");
                    throw new ApplicationException($"Error executing stored procedure {spname}: {ex.Message}", ex);
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        public string UpdateQuery(object parameters, string spname)
        {
            using (IDbConnection dbConnection = new SqlConnection(Conexion()))
            {
                try
                {

                    object result = dbConnection.Query<object>(spname, parameters, commandType: CommandType.StoredProcedure);
                    return JsonConvert.SerializeObject(result);

                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex, $"Error executing stored procedure {spname} with parameters {JsonConvert.SerializeObject(parameters)}");
                    throw new ApplicationException($"Error executing stored procedure {spname}: {ex.Message}", ex);
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        public string OutputQuery(DynamicParameters parameters, string spname, string parametersOutput)
        {
            using (IDbConnection dbConnection = new SqlConnection(Conexion()))
            {
                try
                {
                    dbConnection.Execute(spname, parameters, commandType: CommandType.StoredProcedure);
                    var resultado = parameters.Get<dynamic>(parametersOutput);
                    return JsonConvert.SerializeObject(resultado);
                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex, $"Error executing stored procedure {spname} with parameters {JsonConvert.SerializeObject(parameters)}");
                    throw new ApplicationException($"Error executing stored procedure {spname}: {ex.Message}", ex);
                }
                finally
                {
                    dbConnection.Close();
                }
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
