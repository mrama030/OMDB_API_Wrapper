/*
    OMDB API Wrapper - For all .NET projects (https://docs.microsoft.com/en-us/dotnet/standard/net-standard).
    --------------------------------------------------------------------------------
    Original Author: Mohamed Ali Ramadan (mrama030)
    Available from: https://github.com/mrama030
    Framework Used: .NET Standard 2.0
    Last Modification Date [yyyy-mm-dd]: 2019-01-18
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

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OMDB_API_Wrapper.Models;
using OMDB_API_Wrapper.Models.API_Responses;
using OMDB_API_Wrapper.Models.API_Requests;

namespace OMDB_API_Wrapper
{
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

        // Parameters for "By Title" requests:
        public static readonly string BY_TITLE_PARAM_TITLE = "t";
        public static readonly string BY_TITLE_PARAM_RESULT_TYPE = "type";
        public static readonly string BY_TITLE_PARAM_YEAR_OF_RELEASE = "y";
        public static readonly string BY_TITLE_PARAM_PLOT_LENGTH = "plot";

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
            client.BaseAddress = new Uri($"http://www.omdbapi.com/?apikey={this.OMDB_API_Key}&");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string GenerateByTitleRequestParameters(ByTitleRequest request)
        {
            string parameters = "?apikey=" + this.OMDB_API_Key;

            parameters += "&" + BY_TITLE_PARAM_TITLE + "=" + request.Title.ToLower().Trim();

            if (request.VideoType.HasValue)
            {
                parameters += "&" + BY_TITLE_PARAM_RESULT_TYPE + "=" + request.VideoType.ToString().ToLower();
            }

            if (request.Year.HasValue)
            {
                parameters += "&" + BY_TITLE_PARAM_YEAR_OF_RELEASE + "=" + request.Year.ToString();
            }

            parameters += "&" + BY_TITLE_PARAM_PLOT_LENGTH + "=" + request.PlotSize.ToString().ToLower();

            parameters += "&" + PARAM_RESPONSE_DATA_TYPE;

            return parameters;
        }

        private string GenerateBySearchRequestParameters(BySearchRequest request)
        {
            string parameters = "?apikey=" + this.OMDB_API_Key;
                
            parameters += "&" + BY_SEARCH_PARAM_TITLE + "=" + request.Title.ToLower().Trim();

            if (request.VideoType.HasValue)
            {
                parameters += "&" + BY_SEARCH_PARAM_RESULT_TYPE + "=" + request.VideoType.ToString().ToLower();
            }

            if (request.Year.HasValue)
            {
                parameters += "&" + BY_SEARCH_PARAM_YEAR_OF_RELEASE + "=" + request.Year.ToString();
            }

            parameters += "&" + PARAM_RESPONSE_DATA_TYPE;

            if (request.Page.HasValue)
            {
                parameters += "&" + BY_SEARCH_PARAM_RESULT_PAGE + "=" + request.Page.ToString();
            }

            return parameters;
        }

        private string GenerateByIDRequestParameters(string imdb_id)
        {
            string parameters = "?apikey=" + this.OMDB_API_Key;

            parameters += "&" + BY_ID_PARAM_IMDB_ID + "=" + imdb_id;

            parameters += "&" + PARAM_RESPONSE_DATA_TYPE;

            return parameters;
        }

        #endregion

        #region Public Methods

        public async Task<bool> TestAPIKey()
        {
            ByTitleRequest request = new ByTitleRequest("ghost in the shell", VideoType.Movie, 1995, PlotSize.Short);
            ByTitleResponse response = await ByTitleRequestAsync(request);
            return response.Response;
        }

        public async Task<ByTitleResponse> ByTitleRequestAsync(ByTitleRequest request)
        {
            ByTitleResponse title = null;
            string parameters = GenerateByTitleRequestParameters(request);

            HttpResponseMessage response = await client.GetAsync(parameters);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                title = JsonConvert.DeserializeObject<ByTitleResponse>(jsonContent);
            }

            return title;
        }

        public async Task<ByTitleResponse> ByIDRequestAsync(string imdb_id)
        {
            ByTitleResponse title = null;
            string parameters = GenerateByIDRequestParameters(imdb_id);

            HttpResponseMessage response = await client.GetAsync(parameters);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                title = JsonConvert.DeserializeObject<ByTitleResponse>(jsonContent);
            }

            return title;
        }

        public async Task<BySearchResponse> BySearchRequestAsync(BySearchRequest request)
        {
            BySearchResponse searchResults = null;
            string parameters = GenerateBySearchRequestParameters(request);

            HttpResponseMessage response = await client.GetAsync(parameters);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                searchResults = JsonConvert.DeserializeObject<BySearchResponse>(jsonContent);
            }

            if (request.Page.HasValue == false && searchResults.TotalResults > RESULT_ITEMS_PER_BY_SEARCH_REQUEST) 
            {
                uint searchResultsProcessed = RESULT_ITEMS_PER_BY_SEARCH_REQUEST;
                uint pagesProcessed = 1;

                while (searchResultsProcessed < searchResults.TotalResults)
                {
                    BySearchResponse additional_results = null;
                    BySearchRequest additional_request = new BySearchRequest(request.Title, request.VideoType, request.Year, ++pagesProcessed);
                    string parameters_additional_request = GenerateBySearchRequestParameters(additional_request);

                    HttpResponseMessage additional_response = await client.GetAsync(parameters_additional_request);

                    if (additional_response.IsSuccessStatusCode)
                    {
                        string additional_json_content = await additional_response.Content.ReadAsStringAsync();
                        additional_results = JsonConvert.DeserializeObject<BySearchResponse>(additional_json_content);

                        foreach(BySearchResponse.SearchResultItem resultItem in additional_results.SearchResults)
                        {
                            searchResults.SearchResults.Add(resultItem);
                        }

                        searchResultsProcessed += (uint)additional_results.SearchResults.Count;
                    }
                }
            }

            return searchResults;
        }

        #endregion
    }
}
