using System.Collections.Generic;
using System.Text.Json;

namespace Infrastructure.Response
{
    /// <summary>
    /// Generic error response model to be serialized as json response to http requests.
    /// </summary>
    public sealed class ErrorResponseModel : ResponseModel, IErrorResponseModel
    {
        /// <summary>
        /// Customized errors occurred as per request.
        /// </summary>
        public ICollection<KeyValuePair<string, string>> Errors { get; set; }

        /// <summary>
        /// Creates a new instance of ErrorResponseModel.
        /// </summary>
        public ErrorResponseModel()
        {
            Errors = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Adds a new error to Errors collection.
        /// </summary>
        /// <param name="error">Error detail.</param>
        public void AddError(string error)
        {
            AddError("error", error);
        }

        /// <summary>
        /// Adds a new error to Errors collection.
        /// </summary>
        /// <param name="header">Error header.</param>
        /// <param name="body">Error body.</param>
        public void AddError(string header, string body)
        {
            Errors ??= new List<KeyValuePair<string, string>>();

            Errors.Add(new KeyValuePair<string, string>(header, body));

            Message ??= "An error occured while processing your request.";
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}