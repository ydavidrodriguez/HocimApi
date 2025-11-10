using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Rfx.Commands.Delete
{
    public class DeleteRfxTemplateCommandHandler : IDeleteRfxTemplateCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteRfxTemplateCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<object> Execute(Guid idRfxTemporal)
        {

            var idrfxtemporalservice = _dataBaseService.RfxTemporal.Where(x => x.IdRfxTemporal == idRfxTemporal).FirstOrDefault();

            if (idrfxtemporalservice != null)
            {
                _dataBaseService.RfxTemporal.Remove(idrfxtemporalservice);
                await _dataBaseService.SaveAsync();
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, idRfxTemporal);
        }

    }
}
