using System.Text.Json;
using Application.Models.Base;
using Domain.Models;

namespace Application.Models
{
    /// <summary>
    /// Location DTO model
    /// </summary>
    public class LocationObjectModel : ObjectModelBase<LocationModel>
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Location's Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Latitude of the location
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the location
        /// </summary>
        public double Longitude { get; set; }

        public LocationObjectModel()
        {
        }

        public LocationObjectModel(LocationModel entity)
        {
            AssignFrom(entity);
        }

        public sealed override void AssignFrom(LocationModel entity)
        {
            if (entity == null)
                return;

            LocationId = entity.LocationId;
            Name = entity.Name;
            Latitude = entity.Latitude;
            Longitude = entity.Longitude;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}