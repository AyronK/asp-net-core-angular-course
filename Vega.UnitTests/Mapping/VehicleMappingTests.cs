using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vega.Controllers.Resources;
using Vega.Controllers.Resources.Vehicle;
using Vega.Mapping;
using Vega.Models;
using Vega.Models.JoinEntities;

namespace Vega.UnitTests
{
    [TestClass]
    public class VehicleMappingTests
    {
        private IMapper mapper;

        [TestInitialize]
        public void Initialize()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = mockMapper.CreateMapper();
        }

        [TestMethod]
        public void ShouldNotOverrideDomainId()
        {
            // Arrange
            int initialId = 5;
            Vehicle v = new Vehicle() { Id = initialId };
            SaveVehicleResource vr = new SaveVehicleResource { Id = 0 };

            // Act
            mapper.Map(vr, v);

            // Assert
            Assert.AreEqual(v.Id, initialId);
        }

        [TestMethod]
        public void ShouldRemoveDomainFeatures()
        {
            // Arrange
            Vehicle v = new Vehicle()
            {
                Features = new List<VehicleFeature>()
                {
                    new VehicleFeature(){FeatureId=1},
                    new VehicleFeature(){FeatureId=2},
                    new VehicleFeature(){FeatureId=3}
                }
            };

            SaveVehicleResource vr = new SaveVehicleResource
            {
                Features = new List<int>() { 1 }
            };

            // Act
            mapper.Map(vr, v);

            // Assert
            Assert.IsFalse(v.Features.Any(f => f.FeatureId == 2));
            Assert.IsFalse(v.Features.Any(f => f.FeatureId == 3));
        }

        [TestMethod]
        public void ShouldAddDomainFeatures()
        {
            // Arrange
            Vehicle v = new Vehicle()
            {
                Features = new List<VehicleFeature>()
                {
                    new VehicleFeature(){FeatureId=1}
                }
            };

            SaveVehicleResource vr = new SaveVehicleResource
            {
                Features = new List<int>() { 1, 2, 3 }
            };

            // Act
            mapper.Map(vr, v);

            // Assert
            Assert.IsTrue(v.Features.Any(f => f.FeatureId == 2));
            Assert.IsTrue(v.Features.Any(f => f.FeatureId == 3));
        }

        [TestMethod]
        public void ShouldFetchDomainIds()
        {
            // Arrange
            int featureId1 = 1;
            int featureId2 = 2;
            Vehicle v = new Vehicle()
            {
                Features = new List<VehicleFeature>()
                {
                    new VehicleFeature(){FeatureId=featureId1},
                    new VehicleFeature(){FeatureId=featureId2}
                }
            };

            // Act
            SaveVehicleResource vr = mapper.Map<Vehicle, SaveVehicleResource>(v);

            // Assert
            Assert.AreEqual(v.Features.Count, vr.Features.Count);
            Assert.IsTrue(vr.Features.Contains(featureId1));
            Assert.IsTrue(vr.Features.Contains(featureId2));
        }
    }
}
