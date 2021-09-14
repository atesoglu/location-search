using System;
using System.Text.Json;
using Domain.Models.Base;

namespace Domain.Models
{
    /// <summary>
    /// Location domain model
    /// </summary>
    public class LocationModel : ModelBase
    {
        /// <summary>
        /// Primary key of the location
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Name of the location, presumably the address
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

        /// <summary>
        /// Creates a new instance of LocationModel
        /// </summary>
        public LocationModel()
        {
        }

        /// <summary>
        /// Creates a new instance of LocationModel with given latitude and longitude
        /// </summary>
        /// <param name="latitude">Latitude of the location</param>
        /// <param name="longitude">Longitude of the location</param>
        public LocationModel(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Creates a new instance of LocationModel with given latitude and longitude
        /// </summary>
        /// <param name="name">Name of the location, presumably the address</param>
        /// <param name="latitude">Latitude of the location</param>
        /// <param name="longitude">Longitude of the location</param>
        public LocationModel(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        /*/// <summary>
        /// Creates a new location that is <paramref name="offsetLat"/>, <paramref name="offsetLon"/> meters from this location.
        /// </summary>
        public LocationModel Add(double offsetLat, double offsetLon)
        {
            var latitude = Latitude + offsetLat / 111111d;
            var longitude = Longitude + offsetLon / (111111d * Math.Cos(latitude));

            return new LocationModel(latitude, longitude);
        }*/

        /// <summary>
        /// Calculates the distance between this location and another one, in meters.
        /// </summary>
        public double CalculateDistance(LocationModel locationModel)
        {
            var rlat1 = Math.PI * Latitude / 180;
            var rlat2 = Math.PI * locationModel.Latitude / 180;
            var theta = Longitude - locationModel.Longitude;
            var rtheta = Math.PI * theta / 180;
            var dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1609.344;
        }

        //public override string ToString() => $"{Latitude}, {Longitude}";
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}