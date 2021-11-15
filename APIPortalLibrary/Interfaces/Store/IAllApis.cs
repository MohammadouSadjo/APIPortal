using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models.Store;

namespace APIPortalLibrary.Interfaces.Store
{
    interface IAllApis
    {
        [Headers("X-WSO2-Tenant:", "Accept:application/json", "If-None-Match:")]
        [Get("/api/am/store/v0.14/apis")]
        Task<AllApis> GetAllApis([AliasAs("limit")] int limit, [AliasAs("offset")] int offset, [AliasAs("query")] string query);
        Task<AllApis> GetAllApis();
    }
}
