using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Controllers;
using API.Controllers.Base;
using Application.Flows.Locations.Queries;
using Application.Models;
using Application.Persistence;
using Application.Request;
using FluentAssertions;
using FluentAssertions.Execution;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace API.IntegrationTests.Controllers
{
    public class FilterLocationsControllerShould : IClassFixture<ServicesFixture>
    {
        private readonly IRequestHandler<FilterLocationsCommand, ICollection<LocationObjectModel>> _handler;

        public FilterLocationsControllerShould(ServicesFixture fixture)
        {
            _handler = fixture.ServiceProvider.GetRequiredService<IRequestHandler<FilterLocationsCommand, ICollection<LocationObjectModel>>>();
            fixture.ServiceProvider.GetRequiredService<IDataContext>().SeedData(fixture.ServiceProvider.GetRequiredService<ILogger<ServicesFixture>>());
        }

        [Fact]
        public async Task ResultShouldHavePropertyValueMatch()
        {
            var controller = new FilterLocationsController(_handler, new NullLogger<ApiControllerBase>());

            var command = new FilterLocationsCommand
            {
                Latitude = 50,
                Longitude = 5,
                Distance = 30000,
                Limit = 5
            };

            var response = await controller.FilterLocations(command, CancellationToken.None);

            using (new AssertionScope())
            {
                response.Value.Data.Count.Should().Be(5);
                response.Value.Total.Should().Be(5);
            }
        }
    }
}