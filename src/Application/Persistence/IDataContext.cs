using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    /// <summary>
    /// Generic repository implementation supporting EF core.
    /// </summary>
    public interface IDataContext
    {
        DbSet<LocationModel> Locations { get; set; }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to cancel the action.</param>
        /// <returns>Task wrapping modified entity count.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}