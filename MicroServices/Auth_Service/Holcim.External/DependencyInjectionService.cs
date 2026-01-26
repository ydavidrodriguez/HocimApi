using System.Text.Json;
using System.Text.Json.Serialization;
using Holcim.Application;
using Holcim.Application.External.Dapper;
using Holcim.Application.External.GettokenJwt;
using Holcim.Application.External.Traduccion;
using Holcim.External.Traduccion;
using Holcim.Persistence.Dapper;
using Holcim.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
 
            //string connectionString = $"Server={server},1443;Database={database};Uid={user};Password={password};TrustServerCertificate={Certificate};Encrypt=True"; 

            services.AddScoped<IDataBaseService, DataBaseService>();
            //GetToken
            services.AddTransient<IGettokenJwt, GetTokenJwtService.GetTokenJwtService>();
            services.AddTransient<IDapperProcedure, DapperProcedure>();
            services.AddTransient<IGetTraduccionService, GetTraduccionService>();
            services.AddTransient<ISecretsManagerService, SecretsManagerService>();

            var sp = services.BuildServiceProvider();
            var secretManager = sp.GetRequiredService<ISecretsManagerService>();

            string BDServer = secretManager.GetSecretAsync("esoursing/database").Result ?? string.Empty;
            DbSecrets? databaseSecret = null;
            if (!string.IsNullOrWhiteSpace(BDServer))
            {
                try
                {
                    databaseSecret = JsonSerializer.Deserialize<DbSecrets>(BDServer);
                }
                catch (JsonException)
                {
                    databaseSecret = null;
                }
            }
            // string port = databaseSecret.DBPort;
            // string database = databaseSecret.DBName;
            // string user = databaseSecret.User;
            // string password = databaseSecret.password;
            // string Certificate = true.ToString(); 
            // string server = databaseSecret.DBServer;

              
            string server = configuration["ConnectionStrings:DB_SERVER"] ?? string.Empty;
            string port = configuration["ConnectionStrings:DB_PORT"] ?? string.Empty;
            string database = configuration["ConnectionStrings:DB_NAME"] ?? string.Empty;
            string user = configuration["ConnectionStrings:DB_USER"] ?? string.Empty;
            string password = configuration["ConnectionStrings:DB_PASSWORD"] ?? string.Empty;
            string Certificate = configuration["ConnectionStrings:DB_CERIFICATE"] ?? string.Empty;

            string connectionString = $"Server={server},{port};Database={database};Uid={user};Password={password};Encrypt=True;MultipleActiveResultSets=true;TrustServerCertificate={Certificate}";

            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(connectionString));


            return services;
        }


    }
}
