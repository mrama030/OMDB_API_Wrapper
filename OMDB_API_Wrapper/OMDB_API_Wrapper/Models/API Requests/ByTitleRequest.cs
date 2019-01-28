namespace OMDB_API_Wrapper.Models.API_Requests
{
    /// <summary>
    /// Request object used for Title queries to the OMDB API.
    /// </summary>
    public class ByTitleRequest
    {
        public string Title { get; }
        public VideoType? VideoType { get; }
        public uint? Year { get; }
        public uint? Season { get; }
        public uint? Episode { get; }
        public PlotSize PlotSize { get; }

        /// <summary>
        /// Creates a ByTitleRequest used to obtain information regarding a Movie, TV Series, or TV Series Episode by specifying its exact title.
        /// </summary>
        /// <param name="title">The exact title of the item to be searched for.</param>
        /// <param name="videoType">>Apply a filter for the video type (movie, tv series, episode).</param>
        /// <param name="year">Apply a filter for the year of release.</param>
        /// <param name="plotSize">Specify whether you want a short plot summary of a full-length plot summary in the response. Default is a short plot summary.</param>
        public ByTitleRequest(string title, VideoType? videoType = null, uint? year = null, PlotSize plotSize = PlotSize.Short)
        {
            Title = title;
            VideoType = videoType;
            Year = year;
            PlotSize = plotSize;
        }

        /// <summary>
        /// Creates a ByTitleRequest used to obtain information regarding TV Series Season or TV Series Episode, by specifying its exact title and season number.
        /// </summary>
        /// <param name="title">The exact title of the TV Series Season or TV Series Episode to be searched for.</param>
        /// <param name="season">The season number of the TV Series Season or TV Series Episode.</param>
        /// <param name="episode">Not specifying a specific episode number will return information about all episodes in the season.</param>
        /// <param name="year">Apply a filter for the year of release.</param>
        /// <param name="plotSize">Specify whether you want a short plot summary of a full-length plot summary in the response. Default is a short plot summary.</param>
        public ByTitleRequest(string title, uint season, uint? episode = null, uint? year = null, PlotSize plotSize = PlotSize.Short)
        {
            Title = title;
            VideoType = Models.VideoType.Series;
            Season = season;
            Episode = episode;
            Year = year;
            PlotSize = PlotSize;
        }
    }
}
