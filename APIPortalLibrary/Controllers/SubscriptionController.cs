﻿using APIPortalLibrary.Configuration;
using APIPortalLibrary.Interfaces.Store;
using APIPortalLibrary.Models.Store;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Controllers
{
    public class SubscriptionController
    {
        public static async Task<ApiResponse<AllSubscriptions>> AllSubscriptions(string applicationId, int offset = 0, int limit = 0)
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

        public static async Task<ApiResponse<Subscription>> AddSubscription(string tier, string apiIdentifier, string applicationId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(Config.baseUrl)
            };

            var body = "{\"tier\": \"" + tier + "\"," +
                       "\"apiIdentifier\": \"" + apiIdentifier + "\"," +
                       "\"applicationId\": \"" + applicationId + "\"}";
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
