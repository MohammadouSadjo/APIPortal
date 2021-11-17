using Refit;
using System;
using System.Net.Http;
using APIPortalLibrary.Interfaces.Store;
using APIPortalLibrary.Models.Store;
using APIPortalLibrary.Interfaces.Authentication;
using APIPortalLibrary.Models.Authentication;
using System.Threading.Tasks;
using APIPortalLibrary.Configuration;

namespace APIPortalLibrary
{
    public class Go
    { 
        public static async Task<ClientIDAndSecret> ClientIDSecret()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            ILogin _restApiService = RestService.For<ILogin>(_client);
            
            var clientIDSecret = await _restApiService.GetClientIDSecret(Config.bodyRequestLogin);
            Config.UserInfos.clientId = clientIDSecret.clientId;   
            Config.UserInfos.clientSecret = clientIDSecret.clientSecret;
            
            return clientIDSecret;
        }

        public static async Task<AccessToken> AccessToken(string username, string password)
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
            var grant_type = "password";
            var scope = "apim:subscribe";
 
            var accessToken = await _restApiService.GetAccessToken(authorization, grant_type, username, password, scope);

            Config.UserInfos.accessToken = accessToken.access_token;

            return accessToken;
        }
        public static async Task<AllApis> AllApis(int limit, int offset, string query)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            IAPI _restApiService = RestService.For<IAPI>(_client);

            var allApis = await _restApiService.GetAllApis(limit, offset, query);
       
            return allApis;
        }

        public static async Task<APIDetails> APIDetails(string apiId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            IAPI _restApiService = RestService.For<IAPI>(_client);

            var apiDetails = await _restApiService.GetAllApis(apiId);

            return apiDetails;
        }

        public static async Task<ApplicationDetails> ApplicationDetails(string applicationId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;
            IApplication _restApiService = RestService.For<IApplication>(_client);

            var applicationDetails = await _restApiService.GetApplicationDetails(applicationId, authorization);
            
            return applicationDetails;
        }

        public static async Task<GenerateApplicationKeys> ApplicationKeys(string applicationId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;
            var body = Config.bodyRequestGenerateKeys;
            IApplication _restApiService = RestService.For<IApplication>(_client);
            
            var applicationKeys = await _restApiService.GenerateApplicationKeys(applicationId, authorization, body);

            return applicationKeys;
        }

    }
}
