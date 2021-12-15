using APIPortalLibrary.Configuration;
using APIPortalLibrary.Interfaces;
using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services
{
    public class LoginService
    {
        public static async Task<ApiResponse<ClientIDAndSecret>> ClientIDSecret()// Get clientId and SecretID of the user
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
                ILogin _restApiService = RestService.For<ILogin>(_client);

                var clientIDSecret = await _restApiService.GetClientIDSecret(Config.bodyRequestLogin);

                //set user's clientId and SecretId
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

        public static async Task<ApiResponse<AccessToken>> AccessToken(string username, string password, string scope)//Get access token ofa user by passing his clientId and SecretId
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri("http://localhost:8280")
            };
            ILogin _restApiService = RestService.For<ILogin>(_client);
            //Get user's clientId and SecretId
            var clientId = Config.UserInfos.clientId;
            var clientSecret = Config.UserInfos.clientSecret;
            //Encoding to Bytes
            var textBytes = System.Text.Encoding.UTF8.GetBytes(clientId + ":" + clientSecret);
            //Convert the Obtained Bytes to base64
            var base64 = Convert.ToBase64String(textBytes);

            var authorization = "Basic " + base64;

            try
            {
                var accessToken = await _restApiService.GetAccessToken(authorization, username, password, scope);
                //set user's access token

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
