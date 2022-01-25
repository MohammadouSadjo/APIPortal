using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models;

namespace APIPortalLibrary.Interfaces
{
    interface ISubscription
    {
        //Get all subscriptions
        [Headers("Accept:application/json")]
        [Get("/api/am/devportal/v2/subscriptions")]
        Task<ApiResponse<AllSubscriptions>> GetAllSubscriptions(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization,
            [AliasAs("offset")] int offset = 0,
            [AliasAs("limit")] int limit = 0,
            [AliasAs("groupId")] string groupId = ""
            );

        //Get details of a subscription
        [Headers("Accept:application/json")]
        [Get("/api/am/devportal/v2/subscriptions/{subscriptionId}")]
        Task<ApiResponse<Subscription>> GetSubscriptionsDetails(
            [AliasAs("subscriptionId")] string subscriptionId,
            [Header("Authorization")] string authorization
            );

        //Add a new subscription
        [Headers("Content-Type:application/json")]
        [Post("/api/am/devportal/v2/subscriptions")]
        Task<ApiResponse<Subscription>> AddSubscription(
            [Body] string body,
            [Header("Authorization")] string authorization
            );

        //Add multiple subscriptions
        [Headers("Content-Type:application/json")]
        [Post("/api/am/devportal/v2/subscriptions/multiple")]
        Task<ApiResponse<List<Subscription>>> AddSubscriptionMultiple(
            [Body] List<Subscription> body,
            [Header("Authorization")] string authorization
            );

        //Delete subscription
        [Delete("/api/am/devportal/v2/subscriptions/{subscriptionId}")]
        Task<ApiResponse<Subscription>> DeleteSubscription(
            [AliasAs("subscriptionId")] string subscriptionId,
            [Header("Authorization")] string authorization
            );
    }
}
