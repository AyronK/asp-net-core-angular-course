using System.Linq;
using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Models.JoinEntities;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Features, opts =>
                    opts.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

            // API Resource to Domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.Features, opts => opts.Ignore())
                .ForMember(v => v.Id, opts => opts.Ignore())
                .AfterMap((vr, v) =>
                {
                    // Remove features
                    var removedFeatures = v.Features
                        .Where(f => !vr.Features.Contains(f.FeatureId))
                        .ToList();

                    foreach (var f in removedFeatures)
                        v.Features.Remove(f);

                    // Add new features
                    var addedFeatures = vr.Features
                        .Where(id => v.Features.All(f => f.FeatureId != id))
                        .Select(id => new VehicleFeature { FeatureId = id })
                        .ToList();

                    foreach (var f in addedFeatures)
                        v.Features.Add(f);
                });
        }
    }
}