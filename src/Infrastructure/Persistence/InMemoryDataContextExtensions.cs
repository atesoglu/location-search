using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Application.Persistence;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// In-memory database extensions.
    /// </summary>
    public static class InMemoryDataContextExtensions
    {
        /// <summary>
        /// Seeds the in-memory database with required entities.
        /// </summary>
        /// <param name="dbContext">IDataContext instance to be seeded.</param>
        /// <param name="logger">Logger implementation.</param>
        public static void SeedData(this IDataContext dbContext, ILogger logger)
        {
            logger.LogInformation("Seeding in-memory database context");

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            using (var reader = new StreamReader($@"{Directory.GetCurrentDirectory()}\locations.csv"))
            {
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true }))
                {
                    while (csv.Read())
                    {
                        if (!double.TryParse(csv.GetField(1), out var latitude) || !double.TryParse(csv.GetField(2), out var longitude))
                            continue;

                        dbContext.Locations.Add(new LocationModel { Name = csv.GetField(0), Latitude = latitude, Longitude = longitude });
                    }
                }
            }

            dbContext.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();

            stopWatch.Stop();

            var count = dbContext.Locations.Count();
            var ellapsed = stopWatch.ElapsedMilliseconds / 1000m;
            logger.LogInformation("There are total {count} locations persisted in database. Time ellapsed: {ellapsed} seconds.", count, ellapsed);
        }
    }
}