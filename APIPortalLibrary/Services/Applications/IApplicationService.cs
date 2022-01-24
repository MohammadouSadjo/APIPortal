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
        Task<ApiResponse<Application>> AddApplication(string accessToken, string tokenTypeAuth, string tokenType, string throttlingPolicy, string description, string name);//Add application
        Task<ApiResponse<Application>> UpdateApplication(string accessToken, string tokenTypeAuth, string applicationId, string tokenType, string throttlingPolicy, string description, string name);//Update an application
        Task<ApiResponse<Key>> UpdateGrantTypesAndCallbackUrl(string accessToken, string tokenType, string applicationId, string keyType, List<string> supportedGrantTypes, string callbackUrl);//Update grantTypes and Callback url of an application
        Task<ApiResponse<Application>> DeleteApplication(string accessToken, string tokenType, string applicationId);//Delete an application
        Task<ApiResponse<GenerateApplicationKeys>> GenerateApplicationKeys(string accessToken, string tokenType, string applicationId, string keyType, string keyManager, List<string> grantTypesToBeSupported, string callbackUrl, List<string> scopes, string validityTime);//Generate application keys
    }
}
