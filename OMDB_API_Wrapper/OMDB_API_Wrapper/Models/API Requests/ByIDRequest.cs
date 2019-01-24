namespace OMDB_API_Wrapper.Models.API_Requests
{
    public class ByIDRequest
    {
        public string IMDB_ID { get; }

        public ByIDRequest(string imdb_id)
        {
            IMDB_ID = imdb_id;
        }
    }
}
