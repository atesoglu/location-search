using System.Collections.Generic;
using System.Text.Json;
using Application.Models;
using Application.Request;

namespace Application.Flows.Locations.Queries
{
    /// <summary>
    /// FilterLocationsCommand request
    /// </summary>
    public class FilterLocationsCommand : Request<ICollection<LocationObjectModel>>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }
        public int Limit { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}