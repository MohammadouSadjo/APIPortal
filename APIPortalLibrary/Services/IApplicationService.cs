using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services
{
    public interface IApplicationService
    {
        Task<ApiResponse<AllApplications>> AllApplications(int limit = 25, int offset = 0, string query = "");
        Task<ApiResponse<Application>> ApplicationDetails(string applicationId);
        Task<ApiResponse<Key>> ApplicationKeyDetailsOfGivenType(string applicationId, string keyType, string groupId = "");
        Task<ApiResponse<Application>> AddApplication(string throttlingTier, string description, string name, string callbackUrl, string groupId);
        Task<ApiResponse<Application>> UpdateApplication(string applicationId, string throttlingTier, string description, string name, string callbackUrl, string groupId);
        Task<ApiResponse<Key>> UpdateGrantTypesAndCallbackUrl(string applicationId, string keyType, List<string> supportedGrantTypes, string callbackUrl);
        Task<ApiResponse<Application>> DeleteApplication(string applicationId);
        Task<ApiResponse<GenerateApplicationKeys>> GenerateApplicationKeys(string applicationId);
    }
}
