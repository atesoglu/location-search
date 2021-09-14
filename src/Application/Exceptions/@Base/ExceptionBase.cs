using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Application.Exceptions.Base
{
    public abstract class ExceptionBase : ApplicationException
    {
        public ICollection<KeyValuePair<string, string>> Params { get; }

        protected ExceptionBase(LogLevel level)
        {
            Params = new List<KeyValuePair<string, string>>();
        }

        protected ExceptionBase(string message) : base(message)
        {
            Params = new List<KeyValuePair<string, string>>();
        }

        protected ExceptionBase(string message, Exception innerException) : base(message, innerException)
        {
            Params = new List<KeyValuePair<string, string>>();
        }

        public void AddParam(string key, string value)
        {
            Params.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}