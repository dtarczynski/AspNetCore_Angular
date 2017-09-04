using aspnetcore_spa.Controllers.Resources;
using aspnetcore_spa.Models;
using AutoMapper;
using System.Linq;

namespace aspnetcore_spa.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>().ReverseMap();
            CreateMap<Model, ModelResource>().ReverseMap();            
            // Feature

            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature { FeatureId = id})));

                CreateMap<Vehicle, VehicleResource>()
                    .ForMember(vr => vr.Contact, opt => opt.MapFrom(v=> new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone=v.ContactPhone}))
                    .ForMember(vr => vr.Features, opt=> opt.MapFrom(v=>v.Features.Select(vf=>vf.FeatureId)));
         
        }
    }
}