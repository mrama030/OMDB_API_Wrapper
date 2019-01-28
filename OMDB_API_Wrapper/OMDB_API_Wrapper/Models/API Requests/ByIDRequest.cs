namespace OMDB_API_Wrapper.Models.API_Requests
{
    /// <summary>
    /// Request object used for ID queries to the OMDB API.
    /// </summary>
    public class ByIDRequest
    {
        public string IMDB_ID { get; }
        public PlotSize PlotSize { get; }

        /// <summary>
        /// Creates a ByIDRequest used for obtaining an item by its IMDB (International Movie Database) ID.
        /// </summary>
        /// <param name="imdb_id">The unique ID of the item used by the International Movie Database.</param>
        /// <param name="plotSize">Specify whether you want a short plot summary of a full-length plot summary in the response. Default is a short plot summary.</param>
        public ByIDRequest(string imdb_id, PlotSize plotSize = PlotSize.Short)
        {
            IMDB_ID = imdb_id;
            PlotSize = plotSize;
        }
    }
}
