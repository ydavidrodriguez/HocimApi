using Holcim.Provider.Application;
using Holcim.Provider.Application.External;
using Holcim.Provider.Persistence.Dapper;
using Holcim.Provider.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.Provider.External
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

            string connectionString = $"Server={server},{port};Database={database};Uid={user};Password={password};Trusted_Connection=false;MultipleActiveResultSets=true;TrustServerCertificate={Certificate}";

            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(connectionString));
            ////GetToken
            //services.AddTransient<IGettokenJwt, GetTokenJwtService.GetTokenJwtService>();
            services.AddScoped<IDataBaseService, DataBaseService>(); 
            services.AddTransient<IDapperProcedure, DapperProcedure>();

            return services;
        }

    }
}
