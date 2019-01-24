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
