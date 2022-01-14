using APIPortalLibrary.Configuration;
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
        public async Task<ApiResponse<ClientIDAndSecret>> ClientIDSecret()// Get clientId and SecretID of the user
        {
            try
            {
                ILogin _restApiService = RestService.For<ILogin>(_client);

                var clientIDSecret = await _restApiService.GetClientIDSecret(Config.bodyRequestLogin);

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
