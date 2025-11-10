using Holcim.Translate.Application.DataBase.Translate.Commands.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.Translate.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            //Translate
            services.AddTransient<IPostCreateTranslateCommandHandler, PostCreateTranslateCommandHandler>();

            return services;

        }

    }
}
