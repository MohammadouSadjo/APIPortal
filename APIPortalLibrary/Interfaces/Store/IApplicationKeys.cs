using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models.Store;

namespace APIPortalLibrary.Interfaces.Store
{
    interface IApplicationKeys
    {
        [Headers("Content-Type: application/json")]
        [Post("/api/am/store/v0.14/applications/generate-keys")]
        Task<ApplicationKeys> GetApplicationKeys(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization,
            [Body] string body
            );
    }
}
