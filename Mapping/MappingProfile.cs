using aspnetcore_spa.Controllers.Resources;
using aspnetcore_spa.Models;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;

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
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                        
                        // Remove features
                        var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                        foreach(var f in removedFeatures)
                            v.Features.Remove(f);

                        // Add new Features
                        var addedFeatures = vr.Features.Where(id => !v.Features.Any(f=>f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id});
                        foreach(var f in addedFeatures)
                            v.Features.Add(f);

                });

                CreateMap<Vehicle, VehicleResource>()
                    .ForMember(vr => vr.Contact, opt => opt.MapFrom(v=> new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone=v.ContactPhone}));                    
        }
    }
}