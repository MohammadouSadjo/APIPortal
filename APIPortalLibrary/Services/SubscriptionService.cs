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
    public class SubscriptionService
    {
        public static async Task<ApiResponse<AllSubscriptions>> AllSubscriptions(string applicationId, int offset = 0, int limit = 0)//Get list of all subscription of an application
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            //Set user's authorization
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var allSubscriptions = await _restApiService.GetAllSubscriptions(applicationId, authorization, limit, offset);

                return allSubscriptions;
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

        public static async Task<ApiResponse<Subscription>> SubscriptionDetails(string subsciptionId)// Get details of a given subscription
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            //Set user's authorization
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var subscriptionsDetails = await _restApiService.GetSubscriptionsDetails(subsciptionId, authorization);

                return subscriptionsDetails;
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

        public static async Task<ApiResponse<Subscription>> AddSubscription(string tier, string apiIdentifier, string applicationId) //Add a new subscription
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            //body request
            var body = "{\"tier\": \"" + tier + "\"," +
                       "\"apiIdentifier\": \"" + apiIdentifier + "\"," +
                       "\"applicationId\": \"" + applicationId + "\"}";
            //Set user's authorization
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var addSubscription = await _restApiService.AddSubscription(body, authorization);

                return addSubscription;
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

        public static async Task<ApiResponse<List<Subscription>>> AddSubscriptionMultiple(List<Subscription> Subscriptions) // Add Multiple subscription
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            //set user's authorization
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var addSubscriptionMultiple = await _restApiService.AddSubscriptionMultiple(Subscriptions, authorization);

                return addSubscriptionMultiple;
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

        public static async Task<ApiResponse<Subscription>> DeleteSubscription(string subscriptionId)// Delete a subscription
        {
            //Bypass SSL Certificate
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };
            //set user's authorization
            var authorization = "Bearer " + Config.UserInfos.accessToken;

            try
            {
                ISubscription _restApiService = RestService.For<ISubscription>(_client);

                var deleteSubscription = await _restApiService.DeleteSubscription(subscriptionId, authorization);

                return deleteSubscription;
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
