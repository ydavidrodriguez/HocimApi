using Holcim.Application.Feature;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Rfx.Commands.Update
{
    public class PutUpdatePathRfxCommandHandler : IPutUpdatePathRfxCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;


        public PutUpdatePathRfxCommandHandler(IDataBaseService dataBaseService
            )
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(UpdatePathRfxRequest UpdatePathRfxRequest)
        {

            var rfxupdate = _dataBaseService.Rfx.Where(x => x.IdRfx == UpdatePathRfxRequest.IdRfx)
                .FirstOrDefault();

            if (rfxupdate != null)
            {
                rfxupdate.Path = UpdatePathRfxRequest?.Path;
                _dataBaseService.Rfx.Update(rfxupdate);
                await _dataBaseService.SaveAsync();
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, UpdatePathRfxRequest);
        }

    }
}
