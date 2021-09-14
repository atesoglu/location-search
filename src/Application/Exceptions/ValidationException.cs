using System.Collections.Generic;
using System.Linq;
using Application.Exceptions.Base;
using FluentValidation.Results;

namespace Application.Exceptions
{
    /// <summary>
    /// Validation exception
    /// </summary>
    public class ValidationException : ExceptionBase
    {
        public ICollection<KeyValuePair<string, ICollection<string>>> Errors { get; }

        /// <summary>
        /// Creates a new instance of ValidationException
        /// </summary>
        public ValidationException() : base("One or more validation errors have occurred.")
        {
        }
        /// <summary>
        /// Creates a new instance of ValidationException
        /// </summary>
        /// <param name="errors">Array of validation errors</param>
        public ValidationException(IEnumerable<ValidationFailure> errors) : base("One or more validation errors have occurred.")
        {
            Errors = errors
                .GroupBy(g => g.PropertyName, g => g.ErrorMessage)
                .Select(s => new KeyValuePair<string, ICollection<string>>(s.Key, s.ToList())).ToList();
        }
    }
}