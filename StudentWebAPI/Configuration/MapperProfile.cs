using AutoMapper;
using APICore.Models;
using WebAPI.Models;
using WebApi.Models;

namespace WebAPI.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ModelsAddDto, ModelsCar>()
                .ForMember(dest => dest.CreatedAt, 
                    opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<ModelsCar,  ModelsGetDto>();

            CreateMap<Mar, Marks>();

            CreateMap<ModelsEditDto, ModelsCar>()
                .ForMember(dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.Now));

            //CreateMap<FingerprintBase, FingerprintDto>()
            //    .ForMember(dest => dest.FingerprintId,
            //        opt => opt.MapFrom(src => src.FprtId));
        }
    }
}
