using System.Threading;
using System.Threading.Tasks;

namespace Application.Request
{
    
    /// <summary>
    /// Handler for the request.
    /// </summary>
    /// <typeparam name="TRequest">Type of request container</typeparam>
    public interface IRequestHandler<in TRequest> where TRequest : IRequest
    {
        Task HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
    /// <summary>
    /// Handler for the request 
    /// </summary>
    /// <typeparam name="TRequest">Type of request container</typeparam>
    /// <typeparam name="TResponse">Type of return object for the request</typeparam>
    public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}
