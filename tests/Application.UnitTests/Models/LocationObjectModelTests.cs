using System.Text.Json;
using Application.Models;
using Application.Models.Base;
using Bogus;
using Domain.Models;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.Models
{
    public class LocationObjectModelTests
    {
        [Fact]
        public void ExtendsFromObjectModelBase()
        {
            var actual = new LocationObjectModel();
            actual.Should().BeAssignableTo<ObjectModelBase>();
        }

        [Fact]
        public void ExtendsFromObjectModelBaseOfT()
        {
            var actual = new LocationObjectModel();
            actual.Should().BeAssignableTo<ObjectModelBase<LocationModel>>();
        }

        [Fact]
        public void AssignableFromDomainModel()
        {
            var domainModel = new Faker<LocationModel>()
                .RuleFor(r => r.Latitude, f => f.Random.Double(-90, 90))
                .RuleFor(r => r.Longitude, f => f.Random.Double(-180, 180))
                .Generate();

            var objectModel = new LocationObjectModel(domainModel);
            var assigned = new LocationObjectModel(domainModel);

            assigned.Should().BeEquivalentTo(objectModel, options => options.Excluding(e => e.LocationId));
        }

        [Fact]
        public void NullDomainModelAssignmentReturnsDefault()
        {
            var objectModel = new LocationObjectModel();
            var assigned = new LocationObjectModel(null);

            assigned.Should().BeEquivalentTo(objectModel);
        }

        [Fact]
        public void ToStringSerializedAsJson()
        {
            var objectModel = new Faker<LocationObjectModel>()
                .RuleFor(r => r.Latitude, f => f.Random.Double(-90, 90))
                .RuleFor(r => r.Longitude, f => f.Random.Double(-180, 180))
                .Generate();

            objectModel.ToString().Should().BeEquivalentTo(JsonSerializer.Serialize(objectModel));
        }
    }
}