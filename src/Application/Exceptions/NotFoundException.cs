using System;
using Application.Exceptions.Base;

namespace Application.Exceptions
{
    /// <summary>
    /// Not found exception
    /// </summary>
    public class NotFoundException : ExceptionBase
    {
        /// <summary>
        /// Creates a new instance of InternalServerException
        /// </summary>
        public NotFoundException() : base("The server can not find the requested resource. The resource itself does not exist.")
        {
        }

        /// <summary>
        /// Creates a new instance of NotFoundException
        /// </summary>
        /// <param name="message">Exception message</param>
        public NotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of NotFoundException
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Generic inner exception</param>
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}