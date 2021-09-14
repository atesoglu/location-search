using System.Collections.Generic;

namespace Infrastructure.Response
{
    /// <summary>
    /// Generic health-check response model to be serialized as json response to http requests.
    /// </summary>
    public class HealthCheckResponseModel
    {
        /// <summary>
        /// Overall health status of the health-checks
        /// </summary>
        public string Overall { get; set; }

        /// <summary>
        /// Total duration of the health-checks
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Individual health-check entries.
        /// </summary>
        public ICollection<HealthCheckEntry> Entries { get; }

        /// <summary>
        /// Creates and new instance of HealthCheckResponseModel
        /// </summary>
        public HealthCheckResponseModel()
        {
            Entries = new List<HealthCheckEntry>();
        }
    }

    /// <summary>
    /// Individual health-check entry.
    /// </summary>
    public class HealthCheckEntry
    {
        /// <summary>
        /// Health-check entry name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Health status of the check.
        /// </summary>
        public string Status { get; }

        /// <summary>
        /// Duration of the individual health-check.
        /// </summary>
        public string Duration { get; }

        /// <summary>
        /// Creates a new instance of HealthCheckEntry.
        /// </summary>
        /// <param name="name">Health-check entry name.</param>
        /// <param name="status">Health status of the check.</param>
        /// <param name="duration">Duration of the individual health-check.</param>
        public HealthCheckEntry(string name, string status, string duration)
        {
            Name = name;
            Status = status;
            Duration = duration;
        }
    }
}