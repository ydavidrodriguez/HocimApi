using Holcim.DocumetsService.Application.External;
using Holcim.DocumetsService.Persistence.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.DocumetsService.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<IDataBaseService>(options =>
            //options.UseSqlServer(configuration["sqlconnectionstrings"]));

            //services.AddScoped<IDataBaseService, DataBaseService>();
             //services.AddScoped<IDapperProcedure, DapperProcedure>();
            ////GetToken
            //services.AddTransient<IGettokenJwt, GetTokenJwtService.GetTokenJwtService>();
            services.AddTransient<IDapperProcedure, DapperProcedure>();

            return services;

        }

    }
}
