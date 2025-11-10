using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.List
{
    public class GetListQuestionProviderCommandHandler : IGetListQuestionProviderCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetListQuestionProviderCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure)
        {

            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
        }

        public object Execute(Guid IdRfx)
        {

            var ParametersItemRfx = new { RfxId = IdRfx };
            string ItemsRfx = _dapperProcedure.GetQuery(ParametersItemRfx, "GETPREGUNTAITEMRFX");
            List<ItemResponse> Listitems = JsonConvert.DeserializeObject<List<ItemResponse>>(ItemsRfx);

            PreguntasSobreItemResponse preguntasSobreItemResponse = new PreguntasSobreItemResponse();

            List<PreguntaItemResponse> ListpreguntaItemResponses = new List<PreguntaItemResponse>();

            foreach (var items in Listitems)
            {
                var itemparameters = new { ItemId = items.IdItem };
                string PreguntasItem = _dapperProcedure.GetQuery(itemparameters, "GETPREGUNTAITEMPREGUNTABYRFX");
                List<PreguntaResponse> Preguntaresponse = JsonConvert.DeserializeObject<List<PreguntaResponse>>(PreguntasItem);

                PreguntaItemResponse preguntaItemResponse = new PreguntaItemResponse();


                preguntaItemResponse.Item = items;
                preguntaItemResponse.ListPregunta = Preguntaresponse;

                ListpreguntaItemResponses.Add(preguntaItemResponse);

            }

            preguntasSobreItemResponse.PreguntaItemResponse = ListpreguntaItemResponses;

            var parametersPregunta = new { RfxId = IdRfx };

            string itemssobre = _dapperProcedure.GetQuery(parametersPregunta, "GETPREGUNTAITEMPREGUNTASOBREBYRFX");
            List<PreguntaResponseSobreArchivo> preguntaResponseSobreArchivos = JsonConvert.DeserializeObject<List<PreguntaResponseSobreArchivo>>(itemssobre);

            preguntasSobreItemResponse.ListPreguntaResponseSobreArchivo = preguntaResponseSobreArchivos;


            return ResponseApiService.Response(StatusCodes.Status201Created, preguntasSobreItemResponse);

        }


    }
}
