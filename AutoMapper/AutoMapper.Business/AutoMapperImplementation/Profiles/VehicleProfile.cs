using AutoMapper.Business.Request;
using AutoMapper.Business.Response;
using AutoMapper.Domain.Entities;

namespace AutoMapper.Business.AutoMapperImplementation.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleRequest, Vehicle>()
                .ForMember(origin => origin.Manufacturer, destiny => destiny.MapFrom(source => source.Manufacturer))
                .ReverseMap();

            CreateMap<VehicleResponse, Vehicle>()
                .ForMember(origem => origem.Manufacturer, destiny => destiny.MapFrom(source => source.Manufacturer))
                .ReverseMap();
        }
    }
}
