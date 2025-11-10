using AutoMapper;
using Holcim.AuctionService.Domain.Entities.GanadorSubasta;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Holcim.AuctionService.Domain.Models;
using Holcim.AuctionService.Domain.Models.Subasta;

namespace Holcim.AuctionService.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PostCreateSubastaRequest, Subasta>().ReverseMap();
            CreateMap<PostUpdateSubastaRequest, Subasta>().ReverseMap();
            CreateMap<Subasta, SubastaDto>()
            .ForMember(dest => dest.Items, opt => opt.Ignore());
            CreateMap<PostOtorgarSubasta, GanadorSubasta>()
                .ForMember(dest => dest.ProveedorId,opt => opt.MapFrom(src => src.GanadorId))
                .ReverseMap();
        }

    }
}
