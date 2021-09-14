using Domain.Models;
using Domain.Models.Base;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.Models
{
    public class LocationModelTests
    {
        [Fact]
        public void ExtendsFromModelBase()
        {
            var actual = new LocationModel();
            actual.Should().BeAssignableTo<ModelBase>();
        }

        [Fact]
        public void NamePropertyShouldDefaultToNull()
        {
            var actual = new LocationModel();
            actual.Name.Should().BeNull();
        }
        
    }
}