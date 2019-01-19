using Newtonsoft.Json;
using System.Collections.Generic;

namespace OMDB_API_Wrapper.Models.API_Responses
{
    public class ByTitleResponse
    {
        [JsonProperty("Title")]
        public string Title;

        [JsonProperty("Year")]
        public string Year;

        [JsonProperty("Rated")]
        public string Rated;

        [JsonProperty("Released")]
        public string ReleaseDate;

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
        public uint? Metascore;

        [JsonProperty("imdbRating")]
        public float? IMDB_Rating;

        [JsonProperty("imdbID")]
        public string IMDB_ID;

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
    }
}
