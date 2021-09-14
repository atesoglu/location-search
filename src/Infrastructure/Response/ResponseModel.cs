using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Infrastructure.Response
{
    /// <summary>
    /// Generic response model to be serialized as json response to http requests.
    /// </summary>
    public class ResponseModel : IResponseModel
    {
        /// <summary>
        /// Correlation Id to be used for against requests.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Custom message to be displayed in response body.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Customized parameters as per request.
        /// </summary>
        public ICollection<KeyValuePair<string, string>> Params { get; set; }

        /// <summary>
        /// Creates a new instance of generic response model.
        /// </summary>
        public ResponseModel()
        {
            CorrelationId = Guid.NewGuid().ToString("N");
            Params = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Adds a new parameter to Params collection.
        /// </summary>
        /// <param name="key">Parameter key.</param>
        /// <param name="value">Parameter value.</param>
        public void AddParam(string key, string value)
        {
            Params ??= new List<KeyValuePair<string, string>>();

            Params.Add(new KeyValuePair<string, string>(key, value));
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }

    /// <summary>
    /// Generic response model of T to be serialized as json response to http requests.
    /// </summary>
    /// <typeparam name="T">Generic type T of the Data property</typeparam>
    public sealed class ResponseModel<T> : ResponseModel, IResponseModel<T>
    {
        /// <summary>
        /// Object model to be serialized.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Virtually total count of the entity.
        /// </summary>
        public int Total { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}