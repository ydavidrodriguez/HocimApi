using Holcim.TaskSend.Application;
using Holcim.TaskSend.Application.DataBase.Email.Commands.SendEmail;
using Holcim.TaskSend.Application.External.Dapper;
using Holcim.TaskSend.Application.External.Smtp;
using Holcim.TaskSend.External.Smtp;
using Holcim.TaskSend.Persistence.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.TaskSend.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<DataBaseService>(options =>
            //options.UseSqlServer(configuration["sqlconnectionstrings"]));

            //services.AddScoped<IDataBaseService, DataBaseService>();
            //GetToken
            //services.AddTransient<IGettokenJwt, GetTokenJwtService.GetTokenJwtService>();
            services.AddTransient<ISmtpCommandHandler, SmtpCommandHandler>();
            services.AddTransient<IDapperProcedure, DapperProcedure>();


            return services;
        }


    }
}
