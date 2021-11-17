using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models.Store;

namespace APIPortalLibrary.Interfaces.Store
{
    interface ISubscription
    {
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/subscriptions")]
        Task<AllSubscriptions> GetAllSubscriptions(
            [AliasAs("applicationId")] string applicationId,
            [AliasAs("offset")] int offset,
            [AliasAs("limit")] int limit,
            [Header("Authorization")] string authorization
            );

        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/subscriptions/{subscriptionId}")]
        Task<Subscription> GetSubscriptionsDetails(
            [AliasAs("subscriptionId")] string subscriptionId,
            [Header("Authorization")] string authorization
            );

        [Headers("Content-Type:application/json")]
        [Post("/api/am/store/v0.14/subscriptions")]
        Task<Subscription> AddSubscription(
            [Body] string body,
            [Header("Authorization")] string authorization
            );

        [Delete("/api/am/store/v0.14/subscriptions/{subscriptionId}")]
        Task<Subscription> DeleteSubscription(
            [AliasAs("subscriptionId")] string subscriptionId,
            [Header("Authorization")] string authorization
            );
    }
}
