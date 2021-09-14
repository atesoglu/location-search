using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Events;
using Application.Exceptions;
using Application.Models;
using Application.Persistence;
using Application.Request;
using Application.Services;
using Domain.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Flows.Locations.Queries
{
    /// <summary>
    /// Handler for FilterLocationsCommand
    /// </summary>
    public class FilterLocationsHandler : IRequestHandler<FilterLocationsCommand, ICollection<LocationObjectModel>>
    {
        private readonly IDataContext _repository;
        private readonly IValidator<FilterLocationsCommand> _validator;
        private readonly IEventDispatcherService _eventDispatcherService;
        private readonly ILogger<FilterLocationsHandler> _logger;

        /// <summary>
        /// Creates a new instance of FilterLocationsHandler
        /// </summary>
        /// <param name="repository">IDbContext implementation</param>
        /// <param name="validator">Request object validator</param>
        /// <param name="eventDispatcherService">Event dispatcher service to notify 3rd parties</param>
        /// <param name="logger">Logger implementation</param>
        public FilterLocationsHandler(IDataContext repository, IValidator<FilterLocationsCommand> validator, IEventDispatcherService eventDispatcherService, ILogger<FilterLocationsHandler> logger)
        {
            _repository = repository;
            _validator = validator;
            _eventDispatcherService = eventDispatcherService;
            _logger = logger;
        }

        /// <summary>
        /// Validates the FilterLocationsCommand and if successful returns a collection of LocationObjectModel 
        /// </summary>
        /// <param name="request">FilterLocationsCommand to be handled.</param>
        /// <param name="cancellationToken">Cancellation token to event to be cancelled.</param>
        /// <returns>If successful returns a collection of LocationObjectModel</returns>
        /// <exception cref="Exceptions.ValidationException">If FilterLocationsCommand validation fails, ValidationException is thrown</exception>
        public async Task<ICollection<LocationObjectModel>> HandleAsync(FilterLocationsCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            var location = new LocationModel(request.Latitude, request.Longitude);
            var top = CalculateLocation(location, request.Distance, 0);
            var right = CalculateLocation(location, 0, request.Distance);
            var bottom = CalculateLocation(location, -request.Distance, 0);
            var left = CalculateLocation(location, 0, -request.Distance);

            var domainModels = await _repository.Locations
                .Where(w => w.Latitude <= top.Latitude && w.Latitude >= bottom.Latitude && w.Longitude <= right.Longitude && w.Longitude >= left.Longitude)
                .Take(request.Limit)
                .ToListAsync(cancellationToken);
            var objectModels = new List<LocationObjectModel>();

            var list = new List<KeyValuePair<double, LocationModel>>();

            domainModels.ForEach(domain => { list.Add(new KeyValuePair<double, LocationModel>(domain.CalculateDistance(location), domain)); });

            list.OrderBy(o => o.Key).ToList().ForEach(pair => objectModels.Add(new LocationObjectModel(pair.Value)));

            await _eventDispatcherService.Dispatch(new LocationFilteredEvent(new LocationObjectModel { Latitude = location.Latitude, Longitude = location.Longitude }, request.RequestedAt), cancellationToken);

            return objectModels;
        }

        /// <summary>
        /// Calculates a new location that is <paramref name="offsetLat"/>, <paramref name="offsetLon"/> meters from this location.
        /// </summary>
        private static LocationModel CalculateLocation(LocationModel model, double offsetLat, double offsetLon)
        {
            var latitude = model.Latitude + offsetLat / 111111d;
            var longitude = model.Longitude + offsetLon / (111111d * Math.Cos(latitude));

            return new LocationModel(latitude, longitude);
        }
    }
}