using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Controllers.Base;
using Application.Flows.Locations.Queries;
using Application.Models;
using Application.Request;
using Infrastructure.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    /// <summary>
    /// Request Locations By Sample Location API
    /// </summary>
    public class FilterLocationsController : ApiControllerBase
    {
        private readonly IRequestHandler<FilterLocationsCommand, ICollection<LocationObjectModel>> _handler;

        /// <summary>
        /// Creates a new instance of FilterLocationsController
        /// </summary>
        /// <param name="handler">Command handler.</param>
        /// <param name="logger">Loggerr implementation</param>
        public FilterLocationsController(IRequestHandler<FilterLocationsCommand, ICollection<LocationObjectModel>> handler, ILogger<ApiControllerBase> logger) : base(logger)
        {
            _handler = handler;
        }

        /// <summary>
        /// Returns locations object model list by given sample location 
        /// </summary>
        /// <param name="request">FilterLocationsCommand request parameters wrapper</param>
        /// <param name="cancellationToken">Cancellation token to event to be cancelled.</param>
        /// <returns>If successful, returns an ICollection&lt;LocationObjectModel&gt;</returns>
        [HttpGet("locations")]
        public async Task<ActionResult<IResponseModel<ICollection<LocationObjectModel>>>> FilterLocations([FromQuery] FilterLocationsCommand request, CancellationToken cancellationToken)
        {
            Logger.LogDebug("Locations list by sample location requested.");

            var result = await _handler.HandleAsync(request, cancellationToken);
            var response = new ResponseModel<ICollection<LocationObjectModel>>
            {
                Message = $"Locations are listed with the reference latitude: {request.Latitude} and longitude: {request.Longitude}.",
                Data = result,
                Total = result?.Count ?? 0
            };

            return new ActionResult<IResponseModel<ICollection<LocationObjectModel>>>(response);
        }
    }
}