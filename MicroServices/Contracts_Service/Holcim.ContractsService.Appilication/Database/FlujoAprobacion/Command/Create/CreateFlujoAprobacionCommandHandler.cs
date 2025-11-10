using AutoMapper;
using Holcim.ContractsService.Appilication.Feature;
using Holcim.ContractsService.Domain.Entities.Pasos;
using Holcim.ContractsService.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Holcim.ContractsService.Appilication.Database.FlujoAprobacion.Command.Create
{
    public class CreateFlujoAprobacionCommandHandler : ICreateFlujoAprobacionCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateFlujoAprobacionCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<object> Execute(CreateFlujoAprobacionRequest createFlujoAprobacionRequest)
        {

            var entityFlujoAprobacion = _mapper.Map<Domain.Entities.FlujoAprobacion.FlujoAprobacion>(createFlujoAprobacionRequest);
            entityFlujoAprobacion.IdFlujoAprobacion = Guid.NewGuid();
            entityFlujoAprobacion.Estado = true;
            entityFlujoAprobacion.FechaCreacion = DateTime.Now;
            entityFlujoAprobacion.FechaActualizacion = DateTime.Now;


            _dataBaseService.FlujoAprobacion.Add(entityFlujoAprobacion);

            foreach(var pasoflujoitem in createFlujoAprobacionRequest.pasosFlujoRequest) 
            {
                PasoFlujo pasoFlujo = new PasoFlujo();

                pasoFlujo.IdPasoFlujo = Guid.NewGuid();
                pasoFlujo.Maximo = pasoflujoitem.Maximo;
                pasoFlujo.FlujoAprobacionId = entityFlujoAprobacion.IdFlujoAprobacion;
                pasoFlujo.TipoMonedaId = pasoFlujo.TipoMonedaId;
                pasoFlujo.Estado = true;
                pasoFlujo.Minimo = pasoflujoitem.Minimo;
                pasoFlujo.Order = pasoflujoitem.Order;  

                _dataBaseService.PasoFlujo.Add(pasoFlujo);

                foreach(var pasosperfilitem in pasoflujoitem.PerfilId) 
                {
                    PasosPerfiles pasosPerfiles = new PasosPerfiles();

                    pasosPerfiles.IdPasosPerfiles = Guid.NewGuid();
                    pasosPerfiles.PerfilId = pasosperfilitem;
                    pasosPerfiles.PasoFlujoId = pasoFlujo.IdPasoFlujo;
                    pasosPerfiles.EnvioCorreo = false;
                    
                    _dataBaseService.PasosPerfiles.Add(pasosPerfiles);

                }

                foreach(var pasostipocontrato in pasoflujoitem.TipoContrato) 
                { 
                    PasosTipoContrato pasosTipoContrato = new PasosTipoContrato();

                    pasosTipoContrato.IdPasosTipoContrato = Guid.NewGuid();
                    pasosTipoContrato.PasoFlujoId = pasoFlujo.IdPasoFlujo;
                    pasosTipoContrato.TipoContratoId = pasostipocontrato;

                    _dataBaseService.PasosTipoContrato.Add(pasosTipoContrato);
                }

            }

            await  _dataBaseService.SaveAsync();

            return ResponseApiService.Response(StatusCodes.Status201Created, createFlujoAprobacionRequest);

        }

    }
}
