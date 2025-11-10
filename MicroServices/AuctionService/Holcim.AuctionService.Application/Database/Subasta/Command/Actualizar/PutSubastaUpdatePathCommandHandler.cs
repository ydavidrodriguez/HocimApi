using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models.Subasta;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Actualizar
{
    public class PutSubastaUpdatePathCommandHandler : IPutSubastaUpdatePathCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        public PutSubastaUpdatePathCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;

        }
        public async Task<object> Execute(UpdatePathSubastaRequest UpdatePathSubastaRequest)
        {

            var subastaupdate = _dataBaseService.Subasta.Where(x => x.IdSubasta == UpdatePathSubastaRequest.IdSubasta)
                .FirstOrDefault();

            if (subastaupdate != null)
            {
                subastaupdate.PathSubasta = UpdatePathSubastaRequest?.Path;
                _dataBaseService.Subasta.Update(subastaupdate);
                await _dataBaseService.SaveAsync();
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, UpdatePathSubastaRequest);
        }
    }
}
