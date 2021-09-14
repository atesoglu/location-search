namespace Application.Request
{
    /// <summary>
    /// Generic http request container
    /// </summary>
    public interface IRequest : IRequestBase
    {
    }

    /// <summary>
    /// Generic http request container with the response data of T.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IRequest<out TResponse> : IRequest
    {
    }
}