using AutoMapper;
using Holcim.AuctionService.Application.Database.Auction.Commands.Invite;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models.Ronda;
using Microsoft.AspNetCore.Http;

namespace Holcim.AuctionService.Application.Database.Ronda.Commands.Create
{
    public class CreateRondaSubastaCommandHandler : ICreateRondaSubastaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;
        private readonly IInviteProviderCommandHandler _inviteProviderHandler;


        public CreateRondaSubastaCommandHandler(IDataBaseService dataBaseService, IMapper mapper, IDapperProcedure dapperProcedure, IInviteProviderCommandHandler inviteProviderHandler)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            _inviteProviderHandler = inviteProviderHandler;

        }

        public async Task<object> Execute(PostCreateRondaRequest postCreateRondaRequest)
        {

            return ResponseApiService.Response(StatusCodes.Status201Created, null);

        }

    }
}
