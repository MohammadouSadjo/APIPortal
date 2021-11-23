using APIPortalLibrary.Configuration;
using APIPortalLibrary.Interfaces.Store;
using APIPortalLibrary.Models.Store;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Controllers
{
    public class APIController
    {
        
        public static async Task<ApiResponse<AllApis>> AllApis(int limit = 25, int offset = 0, string query = "")//Get List of all APIs
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var allApis = await _restApiService.GetAllApis(limit, offset, query);

                return allApis;
            }
            catch (ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }

        }

        public static async Task<ApiResponse<API>> APIDetails(string apiId)//Get Details of a given API
        {
            //ByPass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var apiDetails = await _restApiService.GetApiDetails(apiId);

                return apiDetails;
            }
            catch (ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }

        }
    }
}
