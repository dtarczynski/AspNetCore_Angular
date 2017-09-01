using aspnetcore_spa.Controllers.Resources;
using aspnetcore_spa.Models;
using AutoMapper;

namespace aspnetcore_spa.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>().ReverseMap();
            CreateMap<Model, ModelResource>().ReverseMap();
        }
    }
}