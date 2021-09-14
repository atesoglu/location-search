using Application.Persistence;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// In-memory implementation of IDataContext which extends DbContext
    /// </summary>
    public class InMemoryDataContext : DbContext, IDataContext
    {
        public DbSet<LocationModel> Locations { get; set; }

        public InMemoryDataContext(DbContextOptions<InMemoryDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<LocationModel>(entity => entity.HasKey(t => t.LocationId))
                ;
        }
    }
}