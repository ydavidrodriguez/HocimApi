using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Entities;
using Holcim.Provider.Domain.Models;
using Holcim.Provider.Domain.Models.Pregunta;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Pregunta.Commands.Create
{
    public class PostCreatePercentAnswerCommandHandler : IPostCreatePercentAnswerCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public PostCreatePercentAnswerCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(CreateQuestionPercent createQuestionPercent)
        {
           RespuestaPreguntaPorcentaje respuestaPregunta = _dataBaseService.RespuestaPreguntaPorcentaje.Where(x => x.ProveedorId == createQuestionPercent.ProveedorId && x.RfxId == createQuestionPercent.RfxId).FirstOrDefault();

            if (respuestaPregunta == null)
            {
                var entityQuestionpercent = _mapper.Map<RespuestaPreguntaPorcentaje>(createQuestionPercent);
                entityQuestionpercent.IdRespuestaPreguntaPorcentaje = Guid.NewGuid();

                _dataBaseService.RespuestaPreguntaPorcentaje.Add(entityQuestionpercent);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, createQuestionPercent);

            }
            else
            {
               
                respuestaPregunta.Calificacion = createQuestionPercent.Calificacion;
                respuestaPregunta.Observacion = createQuestionPercent.Observacion;
                _dataBaseService.RespuestaPreguntaPorcentaje.Update(respuestaPregunta);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, "Se actulizo correctamente");
            }
        }

    }
}
