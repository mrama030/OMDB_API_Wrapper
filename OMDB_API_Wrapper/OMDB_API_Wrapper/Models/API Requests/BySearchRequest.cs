namespace OMDB_API_Wrapper.Models.API_Requests
{
    public class BySearchRequest
    {
        public string Title { get; }
        public VideoType? VideoType { get; }
        public uint? Year { get; }
        public uint? Page { get; }

        public BySearchRequest(string title, VideoType? videoType = null, uint? year = null, uint? page = null)
        {
            Title = title;
            VideoType = videoType;
            Year = year;
            Page = page;
        }
    }
}
