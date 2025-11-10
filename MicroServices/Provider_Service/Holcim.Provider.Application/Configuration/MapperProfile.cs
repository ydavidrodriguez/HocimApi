using AutoMapper;
using Holcim.Provider.Domain.Entities;
using Holcim.Provider.Domain.Models;
using Holcim.Provider.Domain.Models.Pregunta;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Holcim.Provider.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        { 
             CreateMap<object, ItemResponse>().ReverseMap();
             CreateMap<ItemResponse, ItemResponse>().ReverseMap();
             CreateMap<RespuestaPregunta, RespuestaPreguntaRequest>().ReverseMap();
             CreateMap<CreateUserProviderRequest, ProveedorUsuario>().ReverseMap();
             CreateMap<RespuestaPreguntaPorcentaje, CreateQuestionPercent>().ReverseMap();
        }

    }
}
