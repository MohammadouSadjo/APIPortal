using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Applications
{
    public interface IApplicationService
    {
        Task<ApiResponse<AllApplications>> AllApplications(string accessToken, string tokenType, int limit = 25, int offset = 0, string query = "");//Get all aplications
        Task<ApiResponse<Application>> ApplicationDetails(string accessToken, string tokenType, string applicationId);//Get application details
        Task<ApiResponse<Key>> ApplicationKeyDetailsOfGivenType(string accessToken, string tokenType, string applicationId, string keyType, string groupId = "");//Get application details of a given type
        Task<ApiResponse<Application>> AddApplication(string accessToken, string tokenType, string throttlingTier, string description, string name, string callbackUrl, string groupId);//Add application
        Task<ApiResponse<Application>> UpdateApplication(string accessToken, string tokenType, string applicationId, string throttlingTier, string description, string name, string callbackUrl, string groupId);//Update an application
        Task<ApiResponse<Key>> UpdateGrantTypesAndCallbackUrl(string accessToken, string tokenType, string applicationId, string keyType, List<string> supportedGrantTypes, string callbackUrl);//Update grantTypes and Callback url of an application
        Task<ApiResponse<Application>> DeleteApplication(string accessToken, string tokenType, string applicationId);//Delete an application
        Task<ApiResponse<GenerateApplicationKeys>> GenerateApplicationKeys(string accessToken, string tokenType, string applicationId, int validityTime, string keyType, List<string> supportedGrantTypes);//Generate application keys
    }
}
