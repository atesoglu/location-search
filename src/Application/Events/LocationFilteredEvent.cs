using System;
using System.Text.Json;
using Application.Events.Base;
using Application.Models;

namespace Application.Events
{
    /// <summary>
    /// Event wrapper for LocationObjectModel
    /// </summary>
    public class LocationFilteredEvent : Event<LocationObjectModel>
    {
        /// <summary>
        /// Creates a new instance of LocationUpdatedEvent
        /// </summary>
        /// <param name="model">Actual DTO</param>
        /// <param name="requestedAt">Request timestamp</param>
        public LocationFilteredEvent(LocationObjectModel model, DateTimeOffset requestedAt) : base(model, requestedAt)
        {
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}