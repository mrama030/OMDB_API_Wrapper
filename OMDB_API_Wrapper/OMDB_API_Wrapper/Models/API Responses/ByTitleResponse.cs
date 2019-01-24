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
    public class ByTitleResponse
    {
        [JsonProperty("Title")]
        public string Title;

        [JsonProperty("totalSeasons")]
        public string TotalSeasons;

        [JsonProperty("Episodes")]
        public List<Episode> EpisodeList;

        [JsonProperty("Year")]
        public string Year;

        [JsonProperty("Rated")]
        public string Rated;

        [JsonProperty("Released")]
        public string ReleaseDate;

        [JsonProperty("Season")]
        public string SeasonNumber;

        [JsonProperty("Episode")]
        public string EpisodeNumber;

        [JsonProperty("Runtime")]
        public string Runtime;

        [JsonProperty("Genre")]
        public string Genre;

        [JsonProperty("Director")]
        public string Director;

        [JsonProperty("Writer")]
        public string Writer;

        [JsonProperty("Actors")]
        public string Actors;

        [JsonProperty("Plot")]
        public string Plot;

        [JsonProperty("Language")]
        public string Language;

        [JsonProperty("Country")]
        public string Country;

        [JsonProperty("Awards")]
        public string Awards;

        [JsonProperty("Poster")]
        public string Poster_URI;

        [JsonProperty("Ratings")]
        public List<Rating> RatingsList;

        [JsonProperty("Metascore")]
        public string Metascore;

        [JsonProperty("imdbRating")]
        public string IMDB_Rating;

        [JsonProperty("imdbVotes")]
        public string IMDB_Votes;

        [JsonProperty("imdbID")]
        public string IMDB_ID;

        [JsonProperty("seriesID")]
        public string Series_ID;

        [JsonProperty("Type")]
        public string Type;

        [JsonProperty("DVD")]
        public string ReleaseDate_DVD;

        [JsonProperty("BoxOffice")]
        public string BoxOffice;

        [JsonProperty("Production")]
        public string Production;

        [JsonProperty("Website")]
        public string Website;

        [JsonProperty("Response")]
        public bool Response;

        public class Rating
        {
            [JsonProperty("Source")]
            public string Source;

            [JsonProperty("Value")]
            public string Value;
        }

        public class Episode
        {
            [JsonProperty("Title")]
            public string Title;

            [JsonProperty("Released")]
            public string ReleaseDate;

            [JsonProperty("Episode")]
            public string EpisodeNumber;

            [JsonProperty("imdbRating")]
            public string IMDB_Rating;

            [JsonProperty("imdbID")]
            public string IMDB_ID;
        }
    }
}
