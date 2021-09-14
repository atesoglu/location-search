using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Flows.Locations.Queries;
using Application.Models;
using Application.Persistence;
using Application.Request;
using FluentAssertions;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Infrastructure.IntegrationTests.Flows.Flights.Queries
{
    public class FilterLocationsHandlerShould : IClassFixture<ServicesFixture>
    {
        private readonly IRequestHandler<FilterLocationsCommand, ICollection<LocationObjectModel>> _handler;

        public FilterLocationsHandlerShould(ServicesFixture fixture)
        {
            _handler = fixture.ServiceProvider.GetRequiredService<IRequestHandler<FilterLocationsCommand, ICollection<LocationObjectModel>>>();
            fixture.ServiceProvider.GetRequiredService<IDataContext>().SeedData(fixture.ServiceProvider.GetRequiredService<ILogger<ServicesFixture>>());
        }

        [Fact]
        public async Task ResultShouldHaveAffectedEntityCountMatch()
        {
            var command = new FilterLocationsCommand
            {
                Latitude = 50,
                Longitude = 5,
                Distance = 30000,
                Limit = 10
            };

            var result = await _handler.HandleAsync(command, CancellationToken.None);

            result.Count.Should().Be(10);
        }
    }
}