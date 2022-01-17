using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Subscriptions
{
    public interface ISubscriptionService
    {
        Task<ApiResponse<AllSubscriptions>> AllSubscriptions(string accessToken, string tokenType, string applicationId, int offset = 0, int limit = 0);
        Task<ApiResponse<Subscription>> SubscriptionDetails(string accessToken, string tokenType, string subsciptionId);
        Task<ApiResponse<Subscription>> AddSubscription(string accessToken, string tokenType, string tier, string apiIdentifier, string applicationId);
        Task<ApiResponse<List<Subscription>>> AddSubscriptionMultiple(string accessToken, string tokenType, List<Subscription> Subscriptions);
        Task<ApiResponse<Subscription>> DeleteSubscription(string accessToken, string tokenType, string subscriptionId);
    }
}
