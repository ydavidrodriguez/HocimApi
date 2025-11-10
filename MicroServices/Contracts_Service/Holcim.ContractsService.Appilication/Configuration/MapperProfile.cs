using AutoMapper;
using Holcim.ContractsService.Domain.Entities.Contratos;
using Holcim.ContractsService.Domain.Entities.FlujoAprobacion;
using Holcim.ContractsService.Domain.Models;

namespace Holcim.ContractsService.Appilication.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contrato, PostCreateContratoRequest>().ReverseMap();
            CreateMap<CreateFlujoAprobacionRequest, FlujoAprobacion>().ReverseMap();

        }
    }
}
