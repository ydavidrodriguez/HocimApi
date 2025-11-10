using AutoMapper;
using Holcim.DocumetsService.Application.Configuration;
using Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Create;
using Holcim.DocumetsService.Application.DataBase.Documentos.Commands.List;
using Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Subasta.Create;
using Holcim.DocumetsService.Application.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.DocumetsService.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());

            });
            services.AddSingleton(mapper.CreateMapper());
            services.AddTransient<ICreateDocumentCommandHandler, CreateDocumentCommandHandler>();
            services.AddTransient<ICreateDocumentRfxCommandHandler, CreateDocumentRfxCommandHandler>();
            services.AddTransient<IPostEnviarDocuments, PostEnviarDocuments>();
            services.AddTransient<IConsultDocumentCommandHandler, ConsultDocumentCommandHandler>();
            services.AddTransient<IPostCreateDocumentRfxInitialCommandHandler, PostCreateDocumentRfxInitialCommandHandler>();
            services.AddTransient<IPostInitialDocumentSubastaCommandHandler, PostInitialDocumentSubastaCommandHandler>();
            return services;
        }
    }
}
