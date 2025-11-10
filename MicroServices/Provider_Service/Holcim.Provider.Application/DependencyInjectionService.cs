using AutoMapper;
using Holcim.Provider.Application.Configuration;
using Holcim.Provider.Application.Database.Pregunta.Commands.Create;
using Holcim.Provider.Application.Database.Pregunta.Commands.List;
using Holcim.Provider.Application.Database.Proveedor.Commands.Create;
using Holcim.Provider.Application.Database.Proveedor.Commands.List;
using Holcim.Provider.Application.Database.Proveedor.Commands.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Holcim.Provider.Application
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
            services.AddTransient<IGetListQuestionProviderCommandHandler, GetListQuestionProviderCommandHandler>();
            services.AddTransient<IGetListRfxProviderCommandHandler, GetListRfxProviderCommandHandler>();
            services.AddTransient<IGetListRfxProviderCommandHandler, GetListRfxProviderCommandHandler>();
            services.AddTransient<IPostResponseCreateQuestionProvider, PostResponseCreateQuestionProvider>();
            services.AddTransient<IGetListQuestionReplyRfxListCommandHandler, GetListQuestionReplyRfxListCommandHandler>();
            services.AddTransient<IGetListQuestionReplyRfxListByRfxidCommandHandler, GetListQuestionReplyRfxListByRfxidCommandHandler>();
            services.AddTransient<IGetQuestionReplyRfxListByProveedorIdCommandHandler, GetQuestionReplyRfxListByProveedorIdCommandHandler>();
            services.AddTransient<ICreateUserProviderByProviderCommandHandler, CreateUserProviderByProviderCommandHandler>();
            services.AddTransient<IGetListUserProviderCommandHandler, GetListUserProviderCommandHandler>();
            services.AddTransient<IUpdateUserProviderByProvider, UpdateUserProviderByProvider>();
            services.AddTransient<IPostCreatePercentAnswerCommandHandler, PostCreatePercentAnswerCommandHandler>();
            services.AddTransient<IGetListQuestionResponseProviderRfxCommandHandler, GetListQuestionResponseProviderRfxCommandHandler>();
            services.AddTransient<IGetPorcentResponseProviderByRfx, GetPorcentResponseProviderByRfx>();
            services.AddTransient<ICreateProviderBulkCommandHandler, CreateProviderBulkCommandHandler>();
            services.AddTransient<IGetListAuctionProviderCommandHandler, GetListAuctionProviderCommandHandler>();
            services.AddTransient<IGetListQuestionReplyRfxListCommandHandler, GetListQuestionReplyRfxListCommandHandler>();
            services.AddTransient<IGetListResponseQuestionProviderCommandHandler, GetListResponseQuestionProviderCommandHandler>();
            services.AddTransient<IUpdateResponseQuestionProviderCommandHandler, UpdateResponseQuestionProviderCommandHandler>();


            return services;

        }


    }
}
