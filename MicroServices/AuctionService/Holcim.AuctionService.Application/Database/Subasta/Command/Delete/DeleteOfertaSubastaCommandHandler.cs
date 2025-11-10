using Holcim.AuctionService.Application.Feature;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Delete
{
    public class DeleteOfertaSubastaCommandHandler : IDeleteOfertaSubastaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        public DeleteOfertaSubastaCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(Guid idOfertaSubasta)
        {
            var oferta = _dataBaseService.OfertaSubasta
                .FirstOrDefault(x => x.IdOfertaSubasta == idOfertaSubasta);
            if (oferta != null)
            {
                _dataBaseService.OfertaSubasta.Remove(oferta);
                await _dataBaseService.SaveAsync();
            }
            return ResponseApiService.Response(StatusCodes.Status201Created, idOfertaSubasta);
        }
    }
}
