using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace api.common.model
{
    public class ResponseError
    {
        /// <summary>
        /// Parameterless constructor for serialization
        /// </summary>
        public ResponseError()
        {

        }

        /// <summary>
        /// Constructor to handle just the message
        /// </summary>
        /// <param name="message">Sets the Message property</param>
        public ResponseError(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets the HTTP Status code for the response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message to return in the error.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the exceptions if one exists
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// gets or sets any additional details which may be associated with the error
        /// </summary>
        public IEnumerable<ResponseErrorDetail> ResponseErrorDetails { get; set; }

        /// <summary>
        /// Returns a JSON string of the serialized <see cref="ResponseErrorDetail"/> object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
