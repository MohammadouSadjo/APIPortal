using Refit;
using System;
using System.Net.Http;
using APIPortalLibrary.Interfaces.Store;
using APIPortalLibrary.Models.Store;
using APIPortalLibrary.Interfaces.Authentication;
using APIPortalLibrary.Models.Authentication;
using System.Threading.Tasks;
using APIPortalLibrary.Configuration;
using System.Collections.Generic;
//using Grpc.Core;

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

            try
            {
                ILogin _restApiService = RestService.For<ILogin>(_client);

                var clientIDSecret = await _restApiService.GetClientIDSecret(Config.bodyRequestLogin);

                Config.UserInfos.clientId = clientIDSecret.clientId;
                Config.UserInfos.clientSecret = clientIDSecret.clientSecret;
                return clientIDSecret;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
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
            try
            {
                var accessToken = await _restApiService.GetAccessToken(authorization,username, password);

                Config.UserInfos.accessToken = accessToken.access_token;

                return accessToken;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }
        public static async Task<ApiResponse<AllApis>> AllApis(int limit = 25, int offset = 0, string query = "")
        {
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
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<API>> APIDetails(string apiId)
        {
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
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<AllApplications>> AllApplications(int limit = 25, int offset = 0, string query ="")
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var applicationDetails = await _restApiService.GetAllApplications(authorization, query, limit, offset);

                return applicationDetails;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<Application>> ApplicationDetails(string applicationId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var applicationDetails = await _restApiService.GetApplicationDetails(applicationId, authorization);

                return applicationDetails;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<Key>> ApplicationKeyDetailsOfGivenType(string applicationId, string keyType, string groupId="")
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var applicationKeyDetailsOfGivenType = await _restApiService.GetApplicationKeyDetailsOfGivenType(applicationId, keyType, authorization, groupId);

                return applicationKeyDetailsOfGivenType;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<Application>> AddApplication(string throttlingTier, string description, string name, string callbackUrl, string groupId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;
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
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<Application>> UpdateApplication(string applicationId, string throttlingTier, string description, string name, string callbackUrl, string groupId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;
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

        public static async Task<ApiResponse<Key>> UpdateGrantTypesAndCallbackUrl(string applicationId, string keyType, List<string> supportedGrantTypes, string callbackUrl)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;
            var body = "{ \"supportedGrantTypes\" : [";
            var count = 1;
            supportedGrantTypes.ForEach(c => {
                if (count != supportedGrantTypes.Count){
                    body = body + "\"" + c + "\",";
                    count = count + 1;
                }
                else
                {
                    body = body + "\"" + c + "\"";
                }
                
            } );
            body = body + "],\"callbackUrl\": \"" + callbackUrl +"\"}";

            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var updateGrantTypesAndCallbackUrl = await _restApiService.UpdateGrantTypesAndCallbackUrl(applicationId, keyType, body, authorization);

                return updateGrantTypesAndCallbackUrl;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<Application>> DeleteApplication(string applicationId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var deleteApplication = await _restApiService.DeleteApplication(applicationId, authorization);

                return deleteApplication;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<GenerateApplicationKeys>> GenerateApplicationKeys(string applicationId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;
            var body = Config.bodyRequestGenerateKeys;
            try
            {
                IApplication _restApiService = RestService.For<IApplication>(_client);

                var applicationKeys = await _restApiService.GenerateApplicationKeys(applicationId, authorization, body);

                return applicationKeys;
            }
            catch(ApiException ex)
            {
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                var message = string.Join("; ", errors.Values);

                throw new Exception(message);
            }
        }

        public static async Task<ApiResponse<AllSubscriptions>> AllSubscriptions(string applicationId, int offset=0, int limit=0)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var allSubscriptions = await _restApiService.GetAllSubscriptions(applicationId, authorization, limit, offset);

                return allSubscriptions;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<Subscription>> SubscriptionDetails(string subsciptionId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var subscriptionsDetails = await _restApiService.GetSubscriptionsDetails(subsciptionId, authorization);

                return subscriptionsDetails;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<Subscription>> AddSubscription(string tier, string apiIdentifier, string applicationId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            
            var body = "{\"tier\": \""+ tier + "\","+
                       "\"apiIdentifier\": \"" + apiIdentifier + "\"," +
                       "\"applicationId\": \"" + applicationId + "\"}";
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var addSubscription = await _restApiService.AddSubscription(body, authorization);

                return addSubscription;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<List<Subscription>>> AddSubscriptionMultiple(List<Subscription> Subscriptions)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var addSubscriptionMultiple = await _restApiService.AddSubscriptionMultiple(Subscriptions, authorization);

                return addSubscriptionMultiple;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<Subscription>> DeleteSubscription(string subscriptionId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var deleteSubscription = await _restApiService.DeleteSubscription(subscriptionId, authorization);

                return deleteSubscription;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<AllDocuments>> AllDocuments(string apiId, int limit = 25, int offset = 0, string tenant = "")
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            try
            {
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var allDocuments = await _restApiService.GetAllDocuments(apiId, limit, offset, tenant);

                return allDocuments;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<Document>> GetDocument(string apiId, string documentId, string tenant = "")
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            try
            {
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var document = await _restApiService.GetDocument(apiId, documentId, tenant);

                return document;
            }
            catch(ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            
        }

        public static async Task<ApiResponse<string>> GetDocumentContent(string apiId, string documentId, string tenant = "")
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            try
            {
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var documentContent = await _restApiService.GetDocumentContent(apiId, documentId, tenant);

                return documentContent;
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
