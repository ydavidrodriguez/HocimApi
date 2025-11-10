using System.Text.Json;
using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public class GetListRfxDraftCommandHandler : IGetListRfxDraftCommandHandle
    {
        private readonly IDataBaseService _dataBaseService;

        public GetListRfxDraftCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(string? Nombre)
        {

            var datos = _dataBaseService.RfxTemporal.ToList();

            List<ListGetRfxRequestDraft> listGetRfxRequestDraft = new List<ListGetRfxRequestDraft>();
           
            foreach (var dato in datos)
            {
                ListGetRfxRequestDraft GetRfxRequestDraft = new ListGetRfxRequestDraft();
                var rfdraft = JsonSerializer.Deserialize<UpdateRfxRequestDraft>(dato.JsonRfx);
                GetRfxRequestDraft.DataPlantilla = rfdraft;
                GetRfxRequestDraft.IdPlantilla = dato.IdRfxTemporal;
                listGetRfxRequestDraft.Add(GetRfxRequestDraft);

            }
            if (!string.IsNullOrEmpty(Nombre))
            {
                listGetRfxRequestDraft = listGetRfxRequestDraft.Where(x => x.DataPlantilla.Nombre.Contains(Nombre)).ToList();
            }
       

            return ResponseApiService.Response(StatusCodes.Status201Created, listGetRfxRequestDraft);
        }
    }
}
