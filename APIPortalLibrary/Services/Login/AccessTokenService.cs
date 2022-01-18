using APIPortalLibrary.Interfaces;
using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Login
{
    public class AccessTokenService : IAccessTokenService
    {
        private HttpClient _client;

        public AccessTokenService(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResponse<AccessToken>> AccessToken(string username, string password, string clientId, string clientSecret)//Get access token ofa user by passing his clientId and SecretId
        {
            ILogin _restApiService = RestService.For<ILogin>(_client);
            
            //Encoding to Bytes
            var textBytes = System.Text.Encoding.UTF8.GetBytes(clientId + ":" + clientSecret);
            //Convert the Obtained Bytes to base64
            var base64 = Convert.ToBase64String(textBytes);

            var authorization = "Basic " + base64;

            try
            {
                var accessToken = await _restApiService.GetAccessToken(authorization, username, password);

                return accessToken;
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
