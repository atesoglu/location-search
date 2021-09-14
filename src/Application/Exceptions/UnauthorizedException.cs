using System;
using Application.Exceptions.Base;

namespace Application.Exceptions
{
    /// <summary>
    /// Not found exception
    /// </summary>
    public class UnauthorizedException : ExceptionBase
    {
        /// <summary>
        /// Creates a new instance of InternalServerException
        /// </summary>
        public UnauthorizedException() : base("The request has not been applied because it lacks valid authentication credentials for the target resource.")
        {
        }

        /// <summary>
        /// Creates a new instance of UnauthorizedException
        /// </summary>
        /// <param name="message">Exception message</param>
        public UnauthorizedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of UnauthorizedException
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Generic inner exception</param>
        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}