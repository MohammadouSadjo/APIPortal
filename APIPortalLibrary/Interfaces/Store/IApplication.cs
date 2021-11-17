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
        [Get("/api/am/store/v0.14/applications/{applicationId}")]
        Task<ApplicationDetails> GetApplicationDetails(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization
            );

        [Headers("Content-Type: application/json")]
        [Post("/api/am/store/v0.14/applications/generate-keys")]
        Task<GenerateApplicationKeys> GenerateApplicationKeys(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization,
            [Body] string body
            );
    }
}
