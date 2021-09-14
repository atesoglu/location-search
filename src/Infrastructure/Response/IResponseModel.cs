using System.Collections.Generic;

namespace Infrastructure.Response
{
    /// <summary>
    /// Generic response model to be serialized as json response to http requests.
    /// </summary>
    public interface IResponseModel
    {
        /// <summary>
        /// Correlation Id to be used for against requests.
        /// </summary>
        string CorrelationId { get; }

        /// <summary>
        /// Custom message to be displayed in response body.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Customized parameters as per request.
        /// </summary>
        ICollection<KeyValuePair<string, string>> Params { get; set; }

        /// <summary>
        /// Adds a new parameter to Params collection.
        /// </summary>
        /// <param name="key">Parameter key.</param>
        /// <param name="value">Parameter value.</param>
        void AddParam(string key, string value);
    }

    /// <summary>
    /// Generic response model of T to be serialized as json response to http requests.
    /// </summary>
    /// <typeparam name="T">Generic type T of the Data property</typeparam>
    public interface IResponseModel<out T> : IResponseModel
    {
        /// <summary>
        /// Object model to be serialized.
        /// </summary>
        T Data { get; }

        /// <summary>
        /// Virtually total count of the entity.
        /// </summary>
        int Total { get; }
    }
}