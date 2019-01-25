namespace OMDB_API_Wrapper.Models
{
    /// <summary>
    /// Used for specifying the video type when creating ByTitleRequests and BySearchRequests.
    /// </summary>
    public enum VideoType
    {
        Movie,
        Series,
        Episode
    }

    /// <summary>
    /// Used for specifying the plot version (short or full) when creating ByTitleRequests, BySearchRequests and ByIDRequests.
    /// </summary>
    public enum PlotSize
    {
        Short,
        Full
    }
}
