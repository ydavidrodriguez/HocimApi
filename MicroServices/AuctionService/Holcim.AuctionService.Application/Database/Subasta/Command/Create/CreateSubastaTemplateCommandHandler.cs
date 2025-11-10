using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Holcim.AuctionService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Create
{
    public class CreateSubastaTemplateCommandHandler : ICreateSubastaTemplateCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;


        public CreateSubastaTemplateCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;

        }


        public async Task<object> Execute(PostCreateSubastaRequest postCreateSubastaRequest)
        {

            SubastaTemporal subastaTemporal = new SubastaTemporal();
            subastaTemporal.IdSubastaTemporal = Guid.NewGuid();
            subastaTemporal.EstadoId = postCreateSubastaRequest.EstadoId.Value;
            subastaTemporal.JsonSubasta = JsonConvert.SerializeObject(postCreateSubastaRequest);

            _dataBaseService.SubastaTemporal.Add(subastaTemporal);
            await _dataBaseService.SaveAsync();

            return ResponseApiService.Response(StatusCodes.Status201Created, postCreateSubastaRequest);

        }

    }
}
