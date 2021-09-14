using System;

namespace Application.Request
{
    /// <summary>
    /// Abstract request implementation
    /// </summary>
    public abstract class Request : IRequest
    {
        /// <summary>
        /// DateTimeOffset of the request timestamp
        /// </summary>
        public DateTimeOffset RequestedAt { get; set; }

        protected Request()
        {
            RequestedAt = DateTimeOffset.Now;
        }
    }

    /// <summary>
    /// Abstract request implementation with the return type Of TResponse
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class Request<TResponse> : Request, IRequest<TResponse>
    {
    }
}