using Newtonsoft.Json;

namespace OMDB_API_Wrapper.Models.API_Responses
{
    public class Response
    {
        /// <summary>
        /// Indicates that the API has returned a data response to a valid request.
        /// </summary>
        [JsonProperty("Response")]
        public bool ResponseSuccess;

        /// <summary>
        /// Error message that accompanies an API response to an invalid request.
        /// </summary>
        [JsonProperty("Error")]
        public string ErrorMessage;
    }
}
