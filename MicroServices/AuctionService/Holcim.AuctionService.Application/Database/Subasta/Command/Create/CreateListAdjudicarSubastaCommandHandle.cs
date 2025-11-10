using AutoMapper;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Entities.GanadorSubasta;
using Holcim.AuctionService.Domain.Models.Subasta;
using Microsoft.AspNetCore.Http;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Create
{
    public class CreateListAdjudicarSubastaCommandHandle : ICreateListAdjudicarSubastaCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateListAdjudicarSubastaCommandHandle(
            IDataBaseService dataBaseService,
            IMapper mapper

         )
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(List<PostOtorgarSubasta> postOtorgarSubasta)
        {
            foreach (var item in postOtorgarSubasta)
            {
                var ganadorEntity = _mapper.Map<GanadorSubasta>(item);
                ganadorEntity.IdGanadorSubasta = Guid.NewGuid();
                _dataBaseService.GanadorSubasta.Add(ganadorEntity);
            }

            await _dataBaseService.SaveAsync();

            return ResponseApiService.Response(StatusCodes.Status200OK, postOtorgarSubasta, string.Empty);

        }

    }
}
