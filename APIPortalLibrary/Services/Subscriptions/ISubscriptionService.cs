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
        Task<ApiResponse<AllSubscriptions>> AllSubscriptions(string accessToken, string tokenType, string applicationId, int offset = 0, int limit = 0);//Get all subscriptions
        Task<ApiResponse<Subscription>> SubscriptionDetails(string accessToken, string tokenType, string subsciptionId);//Get subscription details
        Task<ApiResponse<Subscription>> AddSubscription(string accessToken, string tokenType, string tier, string apiIdentifier, string applicationId);//Add subscription
        Task<ApiResponse<List<Subscription>>> AddSubscriptionMultiple(string accessToken, string tokenType, List<Subscription> Subscriptions);//Add multiple subscriptions
        Task<ApiResponse<Subscription>> DeleteSubscription(string accessToken, string tokenType, string subscriptionId);//Delete subscription
        void SetBaseAdress(Uri uri);
    }
}
