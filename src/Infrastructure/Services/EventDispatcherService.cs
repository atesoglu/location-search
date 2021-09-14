using System.Threading;
using System.Threading.Tasks;
using Application.Events.Base;
using Application.Services;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    /// <summary>
    /// Event dispatcher service to send events to 3rd parties.
    /// </summary>
    public class EventDispatcherService : IEventDispatcherService
    {
        private readonly ILogger<EventDispatcherService> _logger;

        public EventDispatcherService(ILogger<EventDispatcherService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Dispatch event to 3rd parties.
        /// </summary>
        /// <param name="event">Event to be dispatched.</param>
        /// <param name="cancellationToken">Cancellation token to event to be cancelled.</param>
        public async Task Dispatch(EventBase @event, CancellationToken cancellationToken)
        {
            if (@event == null)
            {
                _logger.LogError("Event is null.");
                return;
            }

            /***/
            /* SOME PUBLISHING MECHANISMS */
            /***/

            @event.IsPublished = true;
            _logger.LogInformation("Event is dispatched. Current event name: {Name}. Event data: {evt}", @event.GetType().Name, @event);

            await Task.CompletedTask;
        }
    }
}