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
        Task<ApiResponse<AllApplications>> AllApplications(string accessToken, string tokenType, int limit = 25, int offset = 0, string query = "");
        Task<ApiResponse<Application>> ApplicationDetails(string accessToken, string tokenType, string applicationId);
        Task<ApiResponse<Key>> ApplicationKeyDetailsOfGivenType(string accessToken, string tokenType, string applicationId, string keyType, string groupId = "");
        Task<ApiResponse<Application>> AddApplication(string accessToken, string tokenType, string throttlingTier, string description, string name, string callbackUrl, string groupId);
        Task<ApiResponse<Application>> UpdateApplication(string accessToken, string tokenType, string applicationId, string throttlingTier, string description, string name, string callbackUrl, string groupId);
        Task<ApiResponse<Key>> UpdateGrantTypesAndCallbackUrl(string accessToken, string tokenType, string applicationId, string keyType, List<string> supportedGrantTypes, string callbackUrl);
        Task<ApiResponse<Application>> DeleteApplication(string accessToken, string tokenType, string applicationId);
        Task<ApiResponse<GenerateApplicationKeys>> GenerateApplicationKeys(string accessToken, string tokenType, string applicationId, int validityTime, string keyType, List<string> supportedGrantTypes);
    }
}
