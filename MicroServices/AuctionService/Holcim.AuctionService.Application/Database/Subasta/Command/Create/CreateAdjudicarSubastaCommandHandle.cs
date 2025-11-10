using AutoMapper;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Entities.GanadorSubasta;
using Holcim.AuctionService.Domain.Models.Subasta;
using Microsoft.AspNetCore.Http;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Create
{
    public class CreateAdjudicarSubastaCommandHandle : ICreateAdjudicarSubastaCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateAdjudicarSubastaCommandHandle(
            IDataBaseService dataBaseService,
            IMapper mapper

         )
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(PostOtorgarSubasta postOtorgarSubasta)
        {
            var GanadorEntite = _mapper.Map<GanadorSubasta>(postOtorgarSubasta);

            GanadorEntite.IdGanadorSubasta = Guid.NewGuid();
            _dataBaseService.GanadorSubasta.Add(GanadorEntite);

            await _dataBaseService.SaveAsync();

            return ResponseApiService.Response(StatusCodes.Status200OK, postOtorgarSubasta, string.Empty);

        }

    }
}
