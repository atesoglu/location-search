using System;
using Application.Exceptions.Base;

namespace Application.Exceptions
{
    /// <summary>
    /// Bad request or client based exception
    /// </summary>
    public class BadRequestException : ExceptionBase
    {
        /// <summary>
        /// Creates a new instance of BadRequestException
        /// </summary>
        public BadRequestException() : base("Server cannot or will not process the request due to something that is perceived to be a client error " +
                                            "(e.g., malformed request syntax, invalid request message framing, or deceptive request routing).")
        {
        }

        /// <summary>
        /// Creates a new instance of BadRequestException
        /// </summary>
        /// <param name="message">Exception message</param>
        public BadRequestException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of BadRequestException
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Generic inner exception</param>
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}