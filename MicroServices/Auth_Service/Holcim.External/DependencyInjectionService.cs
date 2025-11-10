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


            string server = configuration["ConnectionStrings:DB_SERVER"];
            string port = configuration["ConnectionStrings:DB_PORT"];
            string database = configuration["ConnectionStrings:DB_NAME"];
            string user = configuration["ConnectionStrings:DB_USER"];
            string password = configuration["ConnectionStrings:DB_PASSWORD"];
            string Certificate = configuration["ConnectionStrings:DB_CERIFICATE"];

            string connectionString = $"Server={server},{port};Database={database};Uid={user};Password={password};Trusted_Connection=false;MultipleActiveResultSets=true;TrustServerCertificate={Certificate}";

            //string connectionString = $"Server={server},1443;Database={database};Uid={user};Password={password};TrustServerCertificate={Certificate};Encrypt=True"; 

            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<IDataBaseService, DataBaseService>();
            //GetToken
            services.AddTransient<IGettokenJwt, GetTokenJwtService.GetTokenJwtService>();
            services.AddTransient<IDapperProcedure, DapperProcedure>();
            services.AddTransient<IGetTraduccionService, GetTraduccionService>();

            return services;
        }


    }
}
