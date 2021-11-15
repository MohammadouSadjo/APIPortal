using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models.Store;

namespace APIPortalLibrary.Interfaces.Store
{
    interface IAPIDetails
    {
        [Get("/api/am/store/v0.14/apis/{apiId}")]
        Task<APIDetails> GetAllApis(
            [AliasAs("apiId")] string apiId,
            [Header("Accept")] string accept);
    }
}
