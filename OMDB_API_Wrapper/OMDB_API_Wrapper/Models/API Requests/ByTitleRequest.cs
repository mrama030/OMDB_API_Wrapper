namespace OMDB_API_Wrapper.Models.API_Requests
{
    public class ByTitleRequest
    {
        public string Title { get; }
        public VideoType? VideoType { get; }
        public uint? Year { get; }
        public uint? Season { get; }
        public uint? Episode { get; }
        public PlotSize PlotSize { get; }

        public ByTitleRequest(string title, VideoType? videoType = null, uint? year = null, PlotSize plotSize = PlotSize.Short)
        {
            Title = title;
            VideoType = videoType;
            Year = year;
            PlotSize = plotSize;
        }

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
