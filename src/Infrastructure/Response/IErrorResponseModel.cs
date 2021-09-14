using System.Collections.Generic;

namespace Infrastructure.Response
{
    /// <summary>
    /// Generic error response model to be serialized as json response to http requests.
    /// </summary>
    public interface IErrorResponseModel : IResponseModel
    {
        /// <summary>
        /// Customized errors occurred as per request.
        /// </summary>
        ICollection<KeyValuePair<string, string>> Errors { get; set; }

        /// <summary>
        /// Adds a new error to Errors collection.
        /// </summary>
        /// <param name="error">Error detail.</param>
        void AddError(string error);

        /// <summary>
        /// Adds a new error to Errors collection.
        /// </summary>
        /// <param name="header">Error header.</param>
        /// <param name="body">Error body.</param>
        void AddError(string header, string body);
    }
}