using System;
using Application.Exceptions.Base;

namespace Application.Exceptions
{
    /// <summary>
    /// Internal server exception
    /// </summary>
    public class InternalServerException : ExceptionBase
    {
        /// <summary>
        /// Creates a new instance of InternalServerException
        /// </summary>
        public InternalServerException() : base("Server encountered an unexpected condition that prevented it from fulfilling the request.")
        {
        }

        /// <summary>
        /// Creates a new instance of InternalServerException
        /// </summary>
        /// <param name="message">Exception message</param>
        public InternalServerException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of InternalServerException
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Generic inner exception</param>
        public InternalServerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}