namespace OMDB_API_Wrapper.Models.API_Requests
{
    public class ByTitleRequest
    {
        public string Title { get; }
        public VideoType? VideoType { get; }
        public uint? Year { get; }
        public PlotSize PlotSize { get; }

        public ByTitleRequest(string title, VideoType? videoType = null, uint? year = null, PlotSize plotSize = PlotSize.Short)
        {
            Title = title;
            VideoType = videoType;
            Year = year;
            PlotSize = plotSize;
        }
    }
}
