using Newtonsoft.Json;
using System.Collections.Generic;

namespace OMDB_API_Wrapper.Models.API_Responses
{
    /// <summary>
    /// JSON-deserialized object received in response to a BySearchRequest.
    /// </summary>
    public class BySearchResponse : Response
    {
        [JsonProperty("Search")]
        public List<SearchResultItem> SearchResults;

        [JsonProperty("totalResults")]
        public uint TotalResults;

        public class SearchResultItem
        {
            [JsonProperty("Title")]
            public string Title;

            [JsonProperty("Year")]
            public string Year;

            [JsonProperty("imdbID")]
            public string IMDB_ID;

            [JsonProperty("Type")]
            public string Type;

            [JsonProperty("Poster")]
            public string Poster_URI;
        }
    }
}
