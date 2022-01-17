using APIPortalLibrary.Interfaces;
using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Applications
{
    public class ApplicationService : IApplicationService
    {
        private HttpClient _client;

        public ApplicationService(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResponse<AllApplications>> AllApplications(string accessToken, string tokenType, int limit = 25, int offset = 0, string query = "")//Get list of all Applications
        {
            var authorization = tokenType +" "+ accessToken;
            
            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var applicationDetails = await _restApiService.GetAllApplications(authorization, query, limit, offset);

                return applicationDetails;
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

        public async Task<ApiResponse<Application>> ApplicationDetails(string accessToken, string tokenType, string applicationId)// Get details of a given application
        {
            //Set user's authorization
            var authorization = tokenType + " " + accessToken;

            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var applicationDetails = await _restApiService.GetApplicationDetails(applicationId, authorization);

                return applicationDetails;
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

        public async Task<ApiResponse<Key>> ApplicationKeyDetailsOfGivenType(string accessToken, string tokenType, string applicationId, string keyType, string groupId = "")//Get application key detals of a given type(Type of key: PRODUCTION or SANDBOX)
        {
            //Set user's authorization
            var authorization = tokenType + " " + accessToken;

            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var applicationKeyDetailsOfGivenType = await _restApiService.GetApplicationKeyDetailsOfGivenType(applicationId, keyType, authorization, groupId);

                return applicationKeyDetailsOfGivenType;
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

        public async Task<ApiResponse<Application>> AddApplication(string accessToken, string tokenType, string throttlingTier, string description, string name, string callbackUrl, string groupId)//Add a new application
        {
            //Set user's authorization
            var authorization = tokenType + " " + accessToken;
            //set body request
            var body = "{\"throttlingTier\": \"" + throttlingTier + "\"," +
                       "\"description\": \"" + description + "\"," +
                       "\"name\": \"" + name + "\"," +
                       "\"callbackUrl\": \"" + callbackUrl + "\"," +
                       "\"groupId\": \"" + groupId + "\"}";
            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var addApplication = await _restApiService.AddApplication(authorization, body);

                return addApplication;
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

        public async Task<ApiResponse<Application>> UpdateApplication(string accessToken, string tokenType, string applicationId, string throttlingTier, string description, string name, string callbackUrl, string groupId)//Update a given application
        {
            //set user's authorization
            var authorization = tokenType + " " + accessToken;
            //set body request
            var body = "{\"throttlingTier\": \"" + throttlingTier + "\"," +
                       "\"description\": \"" + description + "\"," +
                       "\"name\": \"" + name + "\"," +
                       "\"callbackUrl\": \"" + callbackUrl + "\"," +
                       "\"groupId\": \"" + groupId + "\"}";
            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var updateApplication = await _restApiService.UpdateApplication(applicationId, authorization, body);

                return updateApplication;
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

        public async Task<ApiResponse<Key>> UpdateGrantTypesAndCallbackUrl(string accessToken, string tokenType, string applicationId, string keyType, List<string> supportedGrantTypes, string callbackUrl)//Update grantTypes and callback url of an application
        {
            //set user's authorization
            var authorization = tokenType + " " + accessToken;
            //set body request
            var body = "{ \"supportedGrantTypes\" : [";
            var count = 1;
            supportedGrantTypes.ForEach(c => {
                if (count != supportedGrantTypes.Count)
                {
                    body = body + "\"" + c + "\",";
                    count = count + 1;
                }
                else
                {
                    body = body + "\"" + c + "\"";
                }

            });
            body = body + "],\"callbackUrl\": \"" + callbackUrl + "\"}";

            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var updateGrantTypesAndCallbackUrl = await _restApiService.UpdateGrantTypesAndCallbackUrl(applicationId, keyType, body, authorization);

                return updateGrantTypesAndCallbackUrl;
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

        public async Task<ApiResponse<Application>> DeleteApplication(string accessToken, string tokenType, string applicationId)//Delete an application
        {
            //set user's authorization
            var authorization = tokenType + " " + accessToken;

            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var deleteApplication = await _restApiService.DeleteApplication(applicationId, authorization);

                return deleteApplication;
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

        public async Task<ApiResponse<GenerateApplicationKeys>> GenerateApplicationKeys(string accessToken, string tokenType, string applicationId, int validityTime, string keyType, List<string> supportedGrantTypes)//Generate application's Keys
        {
            //Set user's authorization'
            var authorization = tokenType + " " + accessToken;
            //set body request
            var body = "{\"validityTime\": " + validityTime + "," +
                                                        "\"keyType\": \"" + keyType + "\"," +
                                                        "\"accessAllowDomains\": [ \"ALL\" ]," +
                                                        "\"scopes\": [ \"am_application_scope\", \"default\" ]," +
                                                        "\"supportedGrantTypes\": [";
            var count = 1;
            supportedGrantTypes.ForEach(c => {
                if (count != supportedGrantTypes.Count)
                {
                    body = body + "\"" + c + "\",";
                    count = count + 1;
                }
                else
                {
                    body = body + "\"" + c + "\"";
                }

            });
            body = body + "]}";
            
            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var applicationKeys = await _restApiService.GenerateApplicationKeys(applicationId, authorization, body);

                return applicationKeys;
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
