using APIPortalLibrary.Configuration;
using APIPortalLibrary.Interfaces.Authentication;
using APIPortalLibrary.Models.Authentication;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Controllers
{
    public class LoginController
    {
        public static async Task<ApiResponse<ClientIDAndSecret>> ClientIDSecret()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            try
            {
                ILogin _restApiService = RestService.For<ILogin>(_client);

                var clientIDSecret = await _restApiService.GetClientIDSecret(Config.bodyRequestLogin);

                Config.UserInfos.clientId = clientIDSecret.Content.clientId;
                Config.UserInfos.clientSecret = clientIDSecret.Content.clientSecret;
                return clientIDSecret;
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

        public static async Task<ApiResponse<AccessToken>> AccessToken(string username, string password)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri("https://localhost:8243")
            };
            ILogin _restApiService = RestService.For<ILogin>(_client);

            var clientId = Config.UserInfos.clientId;
            var clientSecret = Config.UserInfos.clientSecret;
            var textBytes = System.Text.Encoding.UTF8.GetBytes(clientId + ":" + clientSecret);
            var base64 = Convert.ToBase64String(textBytes);

            var authorization = "Basic " + base64;
            try
            {
                var accessToken = await _restApiService.GetAccessToken(authorization, username, password);

                Config.UserInfos.accessToken = accessToken.Content.access_token;

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
