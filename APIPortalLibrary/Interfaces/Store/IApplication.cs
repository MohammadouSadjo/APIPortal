using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models.Store;

namespace APIPortalLibrary.Interfaces.Store
{
    interface IApplication
    {
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/applications")]
        Task<ApiResponse<AllApplications>> GetAllApplications(
            [AliasAs("query")] string query,
            [AliasAs("limit")] int limit,
            [AliasAs("offset")] int offset,
            [Header("Authorization")] string authorization
            );

        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/applications/{applicationId}")]
        Task<ApiResponse<Application>> GetApplicationDetails(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization
            );

        [Headers("Content-Type: application/json")]
        [Post("/api/am/store/v0.14/applications")]
        Task<ApiResponse<Application>> AddApplication(
            [Header("Authorization")] string authorization,
            [Body] string body
            );

        [Headers("Content-Type: application/json")]
        [Put("/api/am/store/v0.14/applications/{applicationId}")]
        Task<ApiResponse<Application>> UpdateApplication(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization,
            [Body] string body
            );

        [Delete("/api/am/store/v0.14/applications/{applicationId}")]
        Task<ApiResponse<Application>> DeleteApplication(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization
            );

        [Headers("Content-Type: application/json")]
        [Post("/api/am/store/v0.14/applications/generate-keys")]
        Task<ApiResponse<GenerateApplicationKeys>> GenerateApplicationKeys(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization,
            [Body] string body
            );
    }
}
