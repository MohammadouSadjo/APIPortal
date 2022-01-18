using APIPortalLibrary.Interfaces;
using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Tags
{
    public class TagService : ITagService
    {
        private HttpClient _client;

        public TagService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResponse<AllTags>> Alltags(int limit = 25, int offset = 0)//Get List of all Tags
        {
            try
            {
                ITag _restApiService = RestService.For<ITag>(_client);

                var allTags = await _restApiService.GetAllTags(limit, offset);

                return allTags;
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
