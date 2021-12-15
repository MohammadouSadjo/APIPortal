using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models;
using System.Net.Http;

namespace APIPortalLibrary.Interfaces
{
    interface IAPI
    {
        //Get all apis
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/apis")]
        Task<ApiResponse<AllApis>> GetAllApis(
            [AliasAs("limit")] int limit = 25,
            [AliasAs("offset")] int offset = 0,
            [AliasAs("query")] string query = ""
            );

        //Get details of an api
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/apis/{apiId}")]
        Task<ApiResponse<API>> GetApiDetails(
            [AliasAs("apiId")] string apiId
            );

        //Get Swagger definition
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/apis/{apiId}/swagger")]
        Task<ApiResponse<string>> GetSwaggerDefinition(
            [AliasAs("apiId")] string apiId
            );

    }
}
