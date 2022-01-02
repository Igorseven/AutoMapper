using AutoMapper.Business.Request;
using AutoMapper.Business.Response;
using AutoMapper.Domain.Entities;

namespace AutoMapper.Business.AutoMapperImplementation.Profiles
{
    public class ManufactureProfile : Profile
    {

        public ManufactureProfile()
        {

            CreateMap<ManufacturerRequest, Manufacturer>().ReverseMap();

            CreateMap<ManufacturerResponse, Manufacturer>().ReverseMap();
        }
    }
}
