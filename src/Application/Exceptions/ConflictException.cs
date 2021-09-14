using System;
using Application.Exceptions.Base;

namespace Application.Exceptions
{
    /// <summary>
    /// Conflict exception
    /// </summary>
    public class ConflictException : ExceptionBase
    {
        /// <summary>
        /// Creates a new instance of ConflictException
        /// </summary>
        public ConflictException() : base("The request could not be processed because of conflict in the request, such as the requested resource is not in the expected state, " +
                                          "or the result of processing the request would create a conflict within the resource.")
        {
        }

        /// <summary>
        /// Creates a new instance of ConflictException
        /// </summary>
        /// <param name="message">Exception message</param>
        public ConflictException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of ConflictException
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Generic inner exception</param>
        public ConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}