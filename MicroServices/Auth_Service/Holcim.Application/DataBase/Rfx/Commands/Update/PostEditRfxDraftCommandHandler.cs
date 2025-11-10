using AutoMapper;
using Holcim.Application.DataBase.TrazabilidadRfx.Commands.Create;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Rfx.Commands.Update
{
    public class PostEditRfxDraftCommandHandler : IPostEditRfxDraftCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly ICreateTrazabilidadCommandHandler _createTrazabilidadCommandHandler;
        private readonly IMapper _mapper;


        public PostEditRfxDraftCommandHandler(IDataBaseService dataBaseService,
            ICreateTrazabilidadCommandHandler createTrazabilidadCommandHandler,IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _createTrazabilidadCommandHandler = createTrazabilidadCommandHandler;
            _mapper = mapper;
        }
        public async Task<object> Execute(UpdateRfxRequestDraft updateRfxRequestDraft)
        {

            var rfxtemporalupdate =  _dataBaseService.RfxTemporal.
                Where(x => x.IdRfxTemporal == updateRfxRequestDraft.IdRfxTemporal).FirstOrDefault();

            if (rfxtemporalupdate != null)
            {
                rfxtemporalupdate.JsonRfx = JsonConvert.SerializeObject(updateRfxRequestDraft);
                _dataBaseService.RfxTemporal.Update(rfxtemporalupdate);
                await _dataBaseService.SaveAsync();
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, updateRfxRequestDraft);
        }
    }
}
