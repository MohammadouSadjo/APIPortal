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
        public static async Task<AllApis> AllApis()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri("https://localhost:9443")
            };
            IAllApis _restApiService = RestService.For<IAllApis>(_client);

            var limit = 25;
            var offset = 0;
            var query = "";
            var allApis = await _restApiService.GetAllApis(limit, offset, query);
       
            return allApis;
        }

    }
}
