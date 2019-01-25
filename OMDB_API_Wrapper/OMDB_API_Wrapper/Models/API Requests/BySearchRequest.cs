namespace OMDB_API_Wrapper.Models.API_Requests
{
    /// <summary>
    /// Request object used for Search queries to the OMDB API.
    /// </summary>
    public class BySearchRequest
    {
        public string Title { get; }
        public VideoType? VideoType { get; }
        public uint? Year { get; }
        public uint? Page { get; }

        /// <summary>
        /// Create a BySearchRequest by specifying the title (or partial title) of the movie/series/episode in question. Other parameters are optional.
        /// </summary>
        /// <param name="title">The title (or partial title) of the item(s) to be searched for.</param>
        /// <param name="videoType">Apply a filter for the video type (movie, tv series, episode).</param>
        /// <param name="year">Apply a filter for the year of release.</param>
        /// <param name="page">Request a specific page of the search results. Leave blank to return all result pages.</param>
        public BySearchRequest(string title, VideoType? videoType = null, uint? year = null, uint? page = null)
        {
            Title = title;
            VideoType = videoType;
            Year = year;
            Page = page;
        }
    }
}
