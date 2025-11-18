using Holcim.ContractsService.Appilication;
using Holcim.ContractsService.Appilication.External;
using Holcim.ContractsService.Persistence.Dapper;
using Holcim.ContractsService.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.ContractsService.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
            string server = configuration["ConnectionStrings:DB_SERVER"];
            string port = configuration["ConnectionStrings:DB_PORT"];
            string database = configuration["ConnectionStrings:DB_NAME"];
            string user = configuration["ConnectionStrings:DB_USER"];
            string password = configuration["ConnectionStrings:DB_PASSWORD"];
            string Certificate = configuration["ConnectionStrings:DB_CERIFICATE"];

            string connectionString = $"Server={server},{port};Database={database};Uid={user};Password={password};Encrypt=True;MultipleActiveResultSets=true;TrustServerCertificate={Certificate}";


            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<IDataBaseService, DataBaseService>();
            //GetToken
           // services.AddTransient<IGettokenJwt, GetTokenJwtService.GetTokenJwtService>();
            services.AddTransient<IDapperProcedure, DapperProcedure>();

            return services;
        }

    }
}
