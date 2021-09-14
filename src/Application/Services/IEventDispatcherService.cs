using System.Threading;
using System.Threading.Tasks;
using Application.Events.Base;

namespace Application.Services
{
    /// <summary>
    /// Event dispatcher service to send events to 3rd parties.
    /// </summary>
    public interface IEventDispatcherService
    {
        /// <summary>
        /// Dispatch event to 3rd parties.
        /// </summary>
        /// <param name="event">Event to be dispatched.</param>
        /// <param name="cancellationToken">Cancellation token to event to be cancelled.</param>
        Task Dispatch(EventBase @event, CancellationToken cancellationToken);
    }
}