using System.Linq;
using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Controllers.Resources.Vehicle;
using Vega.Core.Models;
using Vega.Core.Models.JoinEntities;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Make, KeyValuePairResourse>();
            CreateMap<Model, KeyValuePairResourse>();
            CreateMap<Feature, KeyValuePairResourse>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(vr => vr.Features, opts =>
                    opts.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Features, opts =>
                    opts.MapFrom(v =>
                        v.Features.Select(vf => new KeyValuePairResourse {Id = vf.Feature.Id, Name = vf.Feature.Name})))
                .ForMember(vr => vr.Make, opts =>
                    opts.MapFrom(v => v.Model.Make));

            // API Resource to Domain
            CreateMap<SaveVehicleResource, Vehicle>()
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
                        .Select(id => new VehicleFeature {FeatureId = id})
                        .ToList();

                    foreach (var f in addedFeatures)
                        v.Features.Add(f);
                });
        }
    }
}