using AutoMapper;
using Holcim.ContractsService.Appilication.External;
using Holcim.ContractsService.Appilication.Feature;
using Holcim.ContractsService.Domain.Models;
using Holcim.ContractsService.Domain.Models.Contrato;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.ContractsService.Appilication.Database.Contratos.Command.Create
{
    public class CreateContratoCommandHandler : ICreateContratoCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public CreateContratoCommandHandler(IDataBaseService dataBaseService, IMapper mapper, IDapperProcedure DapperProcedure)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _dapperProcedure = DapperProcedure;

        }

        public async Task<object> Execute(PostCreateContratoRequest postCreateContratoRequest)
        {
            if (_dataBaseService.Contrato.Where(x => x.Nombre == postCreateContratoRequest.Nombre).FirstOrDefault() == null)
            {
                var parametroestado = new { Nombreestado = "PendienteFlujo", NombreTipoEstado = "Contrato"};
                string estado = _dapperProcedure.GetQuery(parametroestado, "GETSTATEBYNAME");
                List<GetStateId> stateResponses = JsonConvert.DeserializeObject<List<GetStateId>>(estado);


                var Entitymapper = _mapper.Map<Domain.Entities.Contratos.Contrato>(postCreateContratoRequest);
                Entitymapper.IdContrato = Guid.NewGuid();
                Entitymapper.Estado = true;
                Entitymapper.FechaCreacion = DateTime.Now;
                Entitymapper.FechaActulizacion = DateTime.Now;
                Entitymapper.EstadoId = stateResponses[0].IdEstado;
                Entitymapper.TipoContratoId = postCreateContratoRequest.TipoContratoId;
                _dataBaseService.Contrato.Add(Entitymapper);
                await _dataBaseService.SaveAsync();

                postCreateContratoRequest.IdContrato = Entitymapper.IdContrato;

                return ResponseApiService.Response(StatusCodes.Status201Created, postCreateContratoRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Contrato Ya Registrada");
            }
        }


    }
}
