/*
    OMDB_API_Wrapper Demo
    --------------------------------------------------------------------------------
    Description: Demonstrates how to access the OMDB API using the OMDP_API_Wrapper and a basic console application.
*/

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OMDB_API_Wrapper;
using OMDB_API_Wrapper.Models;
using OMDB_API_Wrapper.Models.API_Requests;
using OMDB_API_Wrapper.Models.API_Responses;

namespace OMDB_API_Wrapper_Demo
{
    public class Program
    {
        public static void Main()
        {
            // Allows running an asynchronous main method.
            MainAsync().GetAwaiter().GetResult();
        }

        private static void PrintObjectJsonStyle(object o)
        {
            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
        }

        public static async Task MainAsync()
        {
            Console.WriteLine("The following is a demonstration the OMDB_API_Wrapper.\n");

            #region API Key Validation Demo

            // Ask user for the OMDB API Key.
            Console.WriteLine("Please enter a valid OMDB Key:\n");
            string omdb_api_key = Console.ReadLine();

            // Create the OMDB API Client.
            OmdbClient omdbClient = new OmdbClient(omdb_api_key);

            // Verify if the API Key is valid.
            bool isKeyValid = await omdbClient.IsAPIKeyValid();

            while (isKeyValid == false)
            {
                Console.WriteLine("Please enter a valid OMDB Key to continue demonstration:\n");
                omdb_api_key = Console.ReadLine();

                omdbClient = new OmdbClient(omdb_api_key);
                isKeyValid = omdbClient.IsAPIKeyValid().GetAwaiter().GetResult();

                if (isKeyValid == false)
                {
                    Console.WriteLine("->The API Key is NOT valid.\n");
                }
            }

            Console.WriteLine("->The API Key entered is valid.\n");

            #endregion

            #region ByTitleRequest DEMO

            Console.WriteLine("Here is a demo for requesting a ByTitleRequest:\n");

            // Create a ByTitleRequest.
            ByTitleRequest byTitleRequest = new ByTitleRequest("rick and morty", VideoType.Series);

            // Obtain a ByTitleResponse for the ByTitleRequest asynchronously.
            ByTitleResponse byTitleResponse = await omdbClient.ByTitleRequestAsync(byTitleRequest);

            // Print ByTitleRequest object.
            Console.WriteLine("ByTitleRequest Object Attributes:");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(byTitleRequest))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(byTitleRequest);
                Console.WriteLine("{0}={1}\n", name, value);
            }

            // Print ByTitleResponse object's JSON attributes.
            Console.WriteLine("ByTitleResponse JSON attributes:");
            PrintObjectJsonStyle(byTitleResponse);

            #endregion

            #region ByIDRequest DEMO

            Console.WriteLine("Here is a demo for requesting a ByIDRequest:\n");

            // Create a ByIDRequest.
            ByIDRequest byIDRequest = new ByIDRequest("tt1219827");

            // Obtain a ByTitleResponse for the ByIDRequest asynchronously.
            ByTitleResponse byTitleResponseForIDRequest = await omdbClient.ByIDRequestAsync(byIDRequest);

            // Print ByIDRequest object.
            Console.WriteLine("ByIDRequest Object Attributes:");
            Console.WriteLine($"IMDB_ID = {byIDRequest.IMDB_ID}\n");

            // Print ByTitleResponse object's JSON attributes.
            Console.WriteLine("ByTitleResponse JSON attributes:");
            PrintObjectJsonStyle(byTitleResponseForIDRequest);

            #endregion

            #region BySearchRequest DEMO

            Console.WriteLine("Here is a demo for requesting a BySearchRequest:\n");

            // Create a BySearchRequest.
            BySearchRequest bySearchRequest = new BySearchRequest("ghost in the shell");

            // Obtain a BySearchResponse for the BySearchRequest asynchronously.
            BySearchResponse bySearchResponse = await omdbClient.BySearchRequestAsync(bySearchRequest);

            // Print BySearchRequest object.
            Console.WriteLine("BySearchRequest Object Attributes:");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(bySearchRequest))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(bySearchRequest);
                Console.WriteLine("{0}={1}\n", name, value);
            }

            // Print BySearchResponse object's JSON attributes.
            Console.WriteLine("BySearchResponse JSON attributes:");
            PrintObjectJsonStyle(bySearchResponse);

            #endregion

            // Prevent console from terminating.
            string hold = Console.ReadLine();
        }
    }
}
