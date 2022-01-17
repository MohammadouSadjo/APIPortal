using APIPortalLibrary.Interfaces;
using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.APIs
{
    public class APIService : IAPIService
    {
        private HttpClient _client;

        public APIService(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResponse<AllApis>> AllApis(int limit = 25, int offset = 0, string query = "")//Get List of all APIs
        {
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

        public async Task<ApiResponse<API>> APIDetails(string apiId)//Get Details of a given API
        {
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

        public async Task<ApiResponse<string>> SwaggerDefinition(string apiId)//Get Swagger Definition of a given API
        {
            try
            {
                IAPI _restApiService = RestService.For<IAPI>(_client);

                var swaggerDefinition = await _restApiService.GetSwaggerDefinition(apiId);

                return swaggerDefinition;
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
