using Newtonsoft.Json;
using System.Collections.Generic;

namespace OMDB_API_Wrapper.Models.API_Responses
{
    /// <summary>
    /// JSON-deserialized object received in response to a ByTitleRequest or ByIDRequest.
    /// </summary>
    public class ByTitleResponse : Response
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
