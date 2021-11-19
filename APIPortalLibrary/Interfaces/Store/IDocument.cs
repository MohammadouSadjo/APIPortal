using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models.Store;

namespace APIPortalLibrary.Interfaces.Store
{
    interface IDocument
    {
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/apis/{apiId}/documents")]
        Task<ApiResponse<AllDocuments>> GetAllDocuments(
            [AliasAs("apiId")] string apiId,
            [AliasAs("limit")] int limit = 25,
            [AliasAs("offset")] int offset = 0,
            [Header("X-WSO2-Tenant")] string tenant = ""
            );

        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/apis/{apiId}/documents/{documentId}")]
        Task<ApiResponse<Document>> GetDocument(
            [AliasAs("apiId")] string apiId,
            [AliasAs("documentId")] string documentId,
            [Header("X-WSO2-Tenant")] string tenant = ""
            );
    }
}
