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
    public class ClientIdAndSecretService : IClientIdAndSecretService
    {
        private HttpClient _client;

        public ClientIdAndSecretService(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResponse<ClientIDAndSecret>> ClientIDSecret(string username, string password, string callbackUrl, string clientName, string owner, string grantType, bool saasApp)// Get clientId and SecretID of the user
        {
            //Convert to string
            var saas = saasApp.ToString();
            saas = saas.ToLower();

            //Encoding to Bytes
            var textBytes = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
            //Convert the Obtained Bytes to base64
            var base64 = Convert.ToBase64String(textBytes);

            var authorization = "Basic " + base64;

            var bodyRequestLogin = "{\"callbackUrl\": \""+ callbackUrl +"\"," +
                        "\"clientName\": \""+ clientName +"\"," +
                        "\"owner\": \""+ owner +"\"," +
                        "\"grantType\": \""+ grantType +"\"," +
                        "\"saasApp\": "+ saas +"}";

            try
            {
                ILogin _restApiService = RestService.For<ILogin>(_client);

                var clientIDSecret = await _restApiService.GetClientIDSecret(authorization, bodyRequestLogin);

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
    }
}
