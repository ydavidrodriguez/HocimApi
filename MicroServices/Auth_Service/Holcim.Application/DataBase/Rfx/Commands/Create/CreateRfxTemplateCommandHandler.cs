using Holcim.Application.Feature;
using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Rfx.Commands.Create
{
    public class CreateRfxTemplateCommandHandler : ICreateRfxTemplateCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;


        public CreateRfxTemplateCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(CreateRfxRequestDraft createRfxRequestDraft)
        {
            RfxTemporal rfxTemporal = new RfxTemporal();
            rfxTemporal.IdRfxTemporal = Guid.NewGuid();
            rfxTemporal.EstadoId = createRfxRequestDraft.EstadoId.Value;
            rfxTemporal.JsonRfx = JsonConvert.SerializeObject(createRfxRequestDraft);

            _dataBaseService.RfxTemporal.Add(rfxTemporal);
            await _dataBaseService.SaveAsync();

            return ResponseApiService.Response(StatusCodes.Status201Created, createRfxRequestDraft);

        }

    }
}
