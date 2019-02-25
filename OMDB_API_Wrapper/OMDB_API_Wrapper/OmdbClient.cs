/*
    OMDB API Wrapper - For all .NET projects (https://docs.microsoft.com/en-us/dotnet/standard/net-standard).
    --------------------------------------------------------------------------------
    Original Author: Mohamed Ali Ramadan (mrama030)
    Available from: https://github.com/mrama030
    Framework Used: .NET Standard 2.0
    --------------------------------------------------------------------------------
    Description:
    This is an easy to use RESTful API wrapper for the Open Movie Database API available from: http://www.omdbapi.com/
    It allows using creating an OMDB client and performing HTTP GET requests of the three
    types identified in the OMDB API documentation: "By Title", "By ID" and "By Search".

    Instructions:
    1. Get your OMDB API Key from http://www.omdbapi.com/
    2. Install the OMDB_API_Wrapper (Nuget package) for your project.
    3. Install the following dependencies (Nuget packages) to your project if not automatically installed:
        - Newtonsoft.Json (v12.0.1)
*/

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OMDB_API_Wrapper.Models;
using OMDB_API_Wrapper.Models.API_Responses;
using OMDB_API_Wrapper.Models.API_Requests;

namespace OMDB_API_Wrapper
{
    /// <summary>
    /// Client for the OMDB API. Required for performing requests to the OMDB API.
    /// </summary>
    public class OmdbClient
    {
        #region Contants

        public static readonly uint RESULT_ITEMS_PER_BY_SEARCH_REQUEST = 10;

        #endregion

        #region API Request Parameters

        // Request JSON data in the body of HTTP Responses from the API.
        public static readonly string PARAM_RESPONSE_DATA_TYPE = "r=json";

        // Parameter for "By ID" requests:
        public static readonly string BY_ID_PARAM_IMDB_ID = "i";
        public static readonly string BY_ID_PARAM_PLOT_LENGTH = "plot";

        // Parameters for "By Title" requests:
        public static readonly string BY_TITLE_PARAM_TITLE = "t";
        public static readonly string BY_TITLE_PARAM_RESULT_TYPE = "type";
        public static readonly string BY_TITLE_PARAM_YEAR_OF_RELEASE = "y";
        public static readonly string BY_TITLE_PARAM_PLOT_LENGTH = "plot";
        public static readonly string BY_TITLE_PARAM_SEASON = "Season";
        public static readonly string BY_TITLE_PARAM_EPISODE = "Episode";

        // Parameters for "By Search" requests:
        public static readonly string BY_SEARCH_PARAM_TITLE = "s";
        public static readonly string BY_SEARCH_PARAM_RESULT_TYPE = "type";
        public static readonly string BY_SEARCH_PARAM_YEAR_OF_RELEASE = "y";
        public static readonly string BY_SEARCH_PARAM_RESULT_PAGE = "page";

        #endregion

        #region  Class members/attributes

        private string OMDB_API_Key;
        private static HttpClient client;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an OMDB API Client by specifying an OMDB API Key. Validity of API Key should be tested after creation.
        /// </summary>
        /// <param name="omdb_api_key">API Key for the OMDB API.</param>
        public OmdbClient(string omdb_api_key) 
        {
            OMDB_API_Key = omdb_api_key;
            SetupHttpClient();
        }

        #endregion

        #region Private Methods

        private void SetupHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"http://www.omdbapi.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string GenerateByTitleRequestParameters(ByTitleRequest byTitleRequest)
        {
            string parameters = "?apikey=" + this.OMDB_API_Key;

            parameters += "&" + BY_TITLE_PARAM_TITLE + "=" + byTitleRequest.Title.ToLower().Trim();

            if (byTitleRequest.VideoType.HasValue)
            {
                parameters += "&" + BY_TITLE_PARAM_RESULT_TYPE + "=" + byTitleRequest.VideoType.ToString().ToLower();
            }

            if (byTitleRequest.Year.HasValue)
            {
                parameters += "&" + BY_TITLE_PARAM_YEAR_OF_RELEASE + "=" + byTitleRequest.Year.ToString();
            }

            if (byTitleRequest.Season.HasValue)
            {
                parameters += "&" + BY_TITLE_PARAM_SEASON + "=" + byTitleRequest.Season.ToString();

                if (byTitleRequest.Episode.HasValue)
                {
                    parameters += "&" + BY_TITLE_PARAM_EPISODE + "=" + byTitleRequest.Episode.ToString();
                }  
            }

            parameters += "&" + BY_TITLE_PARAM_PLOT_LENGTH + "=" + byTitleRequest.PlotSize.ToString().ToLower();

            parameters += "&" + PARAM_RESPONSE_DATA_TYPE;

            return parameters;
        }

        private string GenerateBySearchRequestParameters(BySearchRequest bySearchRequest)
        {
            string parameters = "?apikey=" + this.OMDB_API_Key;
                
            parameters += "&" + BY_SEARCH_PARAM_TITLE + "=" + bySearchRequest.Title.ToLower().Trim();

            if (bySearchRequest.VideoType.HasValue)
            {
                parameters += "&" + BY_SEARCH_PARAM_RESULT_TYPE + "=" + bySearchRequest.VideoType.ToString().ToLower();
            }

            if (bySearchRequest.Year.HasValue)
            {
                parameters += "&" + BY_SEARCH_PARAM_YEAR_OF_RELEASE + "=" + bySearchRequest.Year.ToString();
            }

            if (bySearchRequest.Page.HasValue)
            {
                parameters += "&" + BY_SEARCH_PARAM_RESULT_PAGE + "=" + bySearchRequest.Page.ToString();
            }

            parameters += "&" + PARAM_RESPONSE_DATA_TYPE;

            return parameters;
        }

        private string GenerateByIDRequestParameters(ByIDRequest byIDRequest)
        {
            string parameters = "?apikey=" + this.OMDB_API_Key;

            parameters += "&" + BY_ID_PARAM_IMDB_ID + "=" + byIDRequest.IMDB_ID;

            parameters += "&" + BY_ID_PARAM_PLOT_LENGTH + "=" + byIDRequest.PlotSize.ToString().ToLower();

            parameters += "&" + PARAM_RESPONSE_DATA_TYPE;

            return parameters;
        }

        #endregion

        #region Asynchronous Public Methods

        /// <summary>
        /// Tests the validity of the API Key asynchronously.
        /// </summary>
        /// <returns>TRUE if OMDB API Key is valid and HTTP Response code is Success. False if specified key generates an HTTP Unauthorized code.</returns>
        public async Task<bool> IsAPIKeyValidAsync()
        {
            ByTitleRequest byTitleRequest = new ByTitleRequest("ghost in the shell", VideoType.Movie, 1995);
            string requestParameters = GenerateByTitleRequestParameters(byTitleRequest);
            HttpResponseMessage response = await client.GetAsync(requestParameters);

            // Verify that HTTP status code is 200 (Success).
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                ByTitleResponse title = JsonConvert.DeserializeObject<ByTitleResponse>(jsonContent);

                // Also verify the ByTitleResponse's Response attribute (called Success in this API wrapper).
                return title.ResponseSuccess;
            }

            return false;
        }

        /// <summary>
        /// Performs a ByTitleRequest asynchronously.
        /// </summary>
        /// <param name="byTitleRequest">Requires a ByTitleRequest object that will be used to specify GET request parameters.</param>
        /// <returns>A ByTitleResponse object.</returns>
        public async Task<ByTitleResponse> ByTitleRequestAsync(ByTitleRequest byTitleRequest)
        {
            ByTitleResponse title = null;
            string parameters = GenerateByTitleRequestParameters(byTitleRequest);

            HttpResponseMessage response = await client.GetAsync(parameters);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                title = JsonConvert.DeserializeObject<ByTitleResponse>(jsonContent);
            }
            else
            {
                throw new HttpRequestException($"ByTitleRequest was unsuccessful with HTTP status code {response.StatusCode.ToString()}");
            }
          
            return title;
        }

        /// <summary>
        /// Performs a ByIDRequest asynchronously.
        /// </summary>
        /// <param name="byIDRequest">Requires a ByIDRequest object that will be used to specify GET request parameters.</param>
        /// <returns>A ByTitleResponse object.</returns>
        public async Task<ByTitleResponse> ByIDRequestAsync(ByIDRequest byIDRequest)
        {
            ByTitleResponse title = null;
            string parameters = GenerateByIDRequestParameters(byIDRequest);

            HttpResponseMessage response = await client.GetAsync(parameters);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                title = JsonConvert.DeserializeObject<ByTitleResponse>(jsonContent);
            }
            else
            {
                throw new HttpRequestException($"ByIDRequest was unsuccessful with HTTP status code {response.StatusCode.ToString()}");
            }

            return title;
        }

        /// <summary>
        /// Performs a BySearchRequest asynchronously.
        /// </summary>
        /// <param name="bySearchRequest">Requires a BySearchRequest object that will be used to specify GET request parameters.</param>
        /// <returns>A BySearchResponse object.</returns>
        public async Task<BySearchResponse> BySearchRequestAsync(BySearchRequest bySearchRequest)
        {
            BySearchResponse bySearchResponse = null;
            string parameters = GenerateBySearchRequestParameters(bySearchRequest);

            HttpResponseMessage response = await client.GetAsync(parameters);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                bySearchResponse = JsonConvert.DeserializeObject<BySearchResponse>(jsonContent);
            }
            else
            {
                throw new HttpRequestException($"BySearchRequest was unsuccessful with HTTP status code {response.StatusCode.ToString()}");
            }

            // If no page number was specified, process all pages (if more than one is found).
            if (bySearchRequest.Page.HasValue == false && bySearchResponse.TotalResults > RESULT_ITEMS_PER_BY_SEARCH_REQUEST) 
            {
                uint searchResultsProcessed = RESULT_ITEMS_PER_BY_SEARCH_REQUEST;
                uint pagesProcessed = 1;

                while (searchResultsProcessed < bySearchResponse.TotalResults)
                {
                    BySearchResponse additional_results = null;
                    BySearchRequest additional_request = new BySearchRequest(bySearchRequest.Title, bySearchRequest.VideoType, bySearchRequest.Year, ++pagesProcessed);
                    string parameters_additional_request = GenerateBySearchRequestParameters(additional_request);

                    HttpResponseMessage additional_response = await client.GetAsync(parameters_additional_request);

                    if (additional_response.IsSuccessStatusCode)
                    {
                        string additional_json_content = await additional_response.Content.ReadAsStringAsync();
                        additional_results = JsonConvert.DeserializeObject<BySearchResponse>(additional_json_content);

                        foreach(BySearchResponse.SearchResultItem resultItem in additional_results.SearchResults)
                        {
                            bySearchResponse.SearchResults.Add(resultItem);
                        }

                        searchResultsProcessed += (uint)additional_results.SearchResults.Count;
                    }
                    else
                    {
                        throw new HttpRequestException($"BySearchRequest was unsuccessful with HTTP status code {response.StatusCode.ToString()}");
                    }
                }
            }

            return bySearchResponse;
        }

        #endregion

        #region Synchronous Public Methods

        /// <summary>
        /// Tests the validity of the API Key synchronously.
        /// </summary>
        /// <returns>TRUE if OMDB API Key is valid and HTTP Response code is Success. False if specified key generates an HTTP Unauthorized code.</returns>
        public bool IsAPIKeyValidSync()
        {
            return IsAPIKeyValidAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs a ByTitleRequest synchronously.
        /// </summary>
        /// <param name="byTitleRequest">Requires a ByTitleRequest object that will be used to specify GET request parameters.</param>
        /// <returns>A ByTitleResponse object.</returns>
        public ByTitleResponse ByTitleRequestSync(ByTitleRequest byTitleRequest)
        {
            return ByTitleRequestAsync(byTitleRequest).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs a ByIDRequest synchronously.
        /// </summary>
        /// <param name="byIDRequest">Requires a ByIDRequest object that will be used to specify GET request parameters.</param>
        /// <returns>A ByTitleResponse object.</returns>
        public ByTitleResponse ByIDRequestSync(ByIDRequest byIDRequest)
        {
            return ByIDRequestAsync(byIDRequest).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs a BySearchRequest synchronously.
        /// </summary>
        /// <param name="bySearchRequest">Requires a BySearchRequest object that will be used to specify GET request parameters.</param>
        /// <returns>A BySearchResponse object.</returns>
        public BySearchResponse BySearchRequestSync(BySearchRequest bySearchRequest)
        {
            return BySearchRequestAsync(bySearchRequest).GetAwaiter().GetResult();
        }

        #endregion
    }
}
