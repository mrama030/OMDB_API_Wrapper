/*
    OMDB API Wrapper - For all .NET projects (https://docs.microsoft.com/en-us/dotnet/standard/net-standard).
    --------------------------------------------------------------------------------
    Original Author: Mohamed Ali Ramadan (mrama030)
    Available from: https://github.com/mrama030
    Framework Used: .NET Standard 2.0
    Last Modification Date [yyyy-mm-dd]: 2019-01-23
    --------------------------------------------------------------------------------
    Description:
    This is an easy to use RESTful API wrapper for the Open Movie Database API available from: http://www.omdbapi.com/
    It allows using creating an OMDB client and performing HTTP GET requests of the three
    types identified in the OMDB API documentation: "By Title", "By ID" and "By Search".

    Instructions:
    1. Get your OMDB API Key from http://www.omdbapi.com/
    2. Install OMDB_API_Wrapper for your project.
    3. Install the following dependencies (Nuget packages) to your project:
        - Newtonsoft.Json (v12.0.1)
*/

using Newtonsoft.Json;
using System.Collections.Generic;

namespace OMDB_API_Wrapper.Models.API_Responses
{
    public class BySearchResponse
    {
        [JsonProperty("Search")]
        public List<SearchResultItem> SearchResults;

        [JsonProperty("totalResults")]
        public uint TotalResults;

        [JsonProperty("Response")]
        public bool Response;

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
