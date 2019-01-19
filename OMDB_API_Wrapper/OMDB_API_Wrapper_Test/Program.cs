using System;
using System.ComponentModel;
using System.Threading.Tasks;
using OMDB_API_Wrapper;
using OMDB_API_Wrapper.Models;
using OMDB_API_Wrapper.Models.API_Requests;
using OMDB_API_Wrapper.Models.API_Responses;

namespace OMDB_API_Wrapper_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("The following is a demonstration of how to use the OMDB_API_Wrapper.\n");
            Console.WriteLine("Please enter a valid OMDB Key:\n");
            string omdb_api_key = Console.ReadLine();
            Console.WriteLine("The program will now verify if this OMDB API Key is valid using the omdbClient.TestAPIKey().\n");

            OmdbClient omdbClient = new OmdbClient(omdb_api_key);
            is_key_valid = await omdbClient.TestAPIKey();

            while (is_key_valid.Result == false)
            {
                Console.WriteLine("Please enter a valid OMDB Key to continue demonstration:\n");
                omdb_api_key = Console.ReadLine();
                is_key_valid = omdbClient.TestAPIKey();
                if (is_key_valid.Result == false)
                {
                    Console.WriteLine("The API Key is NOT valid.\n");
                }
            }

            Console.WriteLine("The API Key is valid.\n");
            Console.WriteLine("Demo #1: By Title Request/Response:\n");
            Console.WriteLine("By Title Request:\n");
            Console.WriteLine("ByTitleRequest titleRequest = new ByTitleRequest(\"ghost in the shell\", VideoType.Movie, 2017, PlotSize.Full);\n");
            Console.WriteLine("ByTitleResponse titleResponse = await omdbClient.ByTitleRequestAsync(titleRequest);\n\n");
            ByTitleRequest titleRequest = new ByTitleRequest("ghost in the shell", VideoType.Movie, 2017, PlotSize.Full);
            Task<ByTitleResponse> titleResponse = omdbClient.ByTitleRequestAsync(titleRequest);
            titleResponse.Start();

            Console.WriteLine("By Title Response Values:");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(titleResponse.Result))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(titleResponse);
                Console.WriteLine("{0}={1}\n", name, value);
            }




            string hold = Console.ReadLine();
        }
        
        
    }
}
