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
        [Get("/api/am/store/v0.14/subscriptions")]
        Task<ApiResponse<AllSubscriptions>> GetAllSubscriptions(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization,
            [AliasAs("offset")] int offset = 0,
            [AliasAs("limit")] int limit = 0
            );

        //Get details of a subscription
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/subscriptions/{subscriptionId}")]
        Task<ApiResponse<Subscription>> GetSubscriptionsDetails(
            [AliasAs("subscriptionId")] string subscriptionId,
            [Header("Authorization")] string authorization
            );

        //Add a new subscription
        [Headers("Content-Type:application/json")]
        [Post("/api/am/store/v0.14/subscriptions")]
        Task<ApiResponse<Subscription>> AddSubscription(
            [Body] string body,
            [Header("Authorization")] string authorization
            );

        //Add multiple subscriptions
        [Headers("Content-Type:application/json")]
        [Post("/api/am/store/v0.14/subscriptions/multiple")]
        Task<ApiResponse<List<Subscription>>> AddSubscriptionMultiple(
            [Body] List<Subscription> body,
            [Header("Authorization")] string authorization
            );

        //Delete subscription
        [Delete("/api/am/store/v0.14/subscriptions/{subscriptionId}")]
        Task<ApiResponse<Subscription>> DeleteSubscription(
            [AliasAs("subscriptionId")] string subscriptionId,
            [Header("Authorization")] string authorization
            );
    }
}
