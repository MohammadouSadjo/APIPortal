using Refit;
using System;
using System.Net.Http;
using APIPortalLibrary.Interfaces.Store;
using APIPortalLibrary.Models.Store;
using System.Threading.Tasks;

namespace APIPortalLibrary
{
    public class Go
    {
        public static async Task<AllApis> AllApis(int limit, int offset, string query)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri("https://localhost:9443")
            };
            IAllApis _restApiService = RestService.For<IAllApis>(_client);

            var allApis = await _restApiService.GetAllApis(limit, offset, query, "application/json");
       
            return allApis;
        }

        public static async Task<APIDetails> APIDetails(string apiId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri("https://localhost:9443")
            };
            IAPIDetails _restApiService = RestService.For<IAPIDetails>(_client);

            var apiDetails = await _restApiService.GetAllApis(apiId, "application/json");

            return apiDetails;
        }

    }
}
