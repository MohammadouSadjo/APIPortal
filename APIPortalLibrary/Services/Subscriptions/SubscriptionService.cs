using APIPortalLibrary.Interfaces;
using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        private HttpClient _client;

        public SubscriptionService(HttpClient client)
        {
            _client = client;
        }

        public void SetBaseAdress(Uri uri)
        {
            _client.BaseAddress = uri;
        }
        public async Task<ApiResponse<AllSubscriptions>> AllSubscriptions(string accessToken, string tokenType, string applicationId, int offset = 0, int limit = 0)//Get list of all subscription of an application
        {
            //Set user's authorization
            var authorization = tokenType + " " + accessToken;

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

        public async Task<ApiResponse<Subscription>> SubscriptionDetails(string accessToken, string tokenType, string subsciptionId)// Get details of a given subscription
        {
            //Set user's authorization
            var authorization = tokenType + " " + accessToken;

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

        public async Task<ApiResponse<Subscription>> AddSubscription(string accessToken, string tokenType, string tier, string apiIdentifier, string applicationId) //Add a new subscription
        {
            //body request
            var body = "{\"tier\": \"" + tier + "\"," +
                       "\"apiIdentifier\": \"" + apiIdentifier + "\"," +
                       "\"applicationId\": \"" + applicationId + "\"}";
            //Set user's authorization
            var authorization = tokenType + " " + accessToken;

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

        public async Task<ApiResponse<List<Subscription>>> AddSubscriptionMultiple(string accessToken, string tokenType, List<Subscription> Subscriptions) // Add Multiple subscription
        {
            //set user's authorization
            var authorization = tokenType + " " + accessToken;

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

        public async Task<ApiResponse<Subscription>> DeleteSubscription(string accessToken, string tokenType, string subscriptionId)// Delete a subscription
        {
            //set user's authorization
            var authorization = tokenType + " " + accessToken;

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
