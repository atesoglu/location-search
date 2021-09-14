using Application.Flows.Locations.Queries;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Infrastructure.IntegrationTests.Flows.Flights.Queries
{
    public class FilterLocationsValidatorShould
    {
        private readonly FilterLocationsValidator _validator;

        public FilterLocationsValidatorShould()
        {
            _validator = new FilterLocationsValidator();
        }

        [Fact]
        public void NotAllowEmptyLatitude()
        {
            var command = new Faker<FilterLocationsCommand>()
                .RuleFor(r => r.Latitude, f => f.Random.Double(-90, 90))
                .RuleFor(r => r.Longitude, f => f.Random.Double(-180, 180))
                .Generate();

            command.Latitude = -100;

            _validator.Validate(command).IsValid.Should().BeFalse();
        }

        [Fact]
        public void NotAllowInvalidLongitude()
        {
            var command = new Faker<FilterLocationsCommand>()
                .RuleFor(r => r.Latitude, f => f.Random.Double(-90, 90))
                .RuleFor(r => r.Longitude, f => f.Random.Double(-180, 180))
                .Generate();

            command.Longitude = 181;

            _validator.Validate(command).IsValid.Should().BeFalse();
        }
    }
}