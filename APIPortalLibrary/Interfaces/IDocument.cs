using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models;

namespace APIPortalLibrary.Interfaces
{
    interface IDocument
    {
        //Get all documents
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/apis/{apiId}/documents")]
        Task<ApiResponse<AllDocuments>> GetAllDocuments(
            [AliasAs("apiId")] string apiId,
            [AliasAs("limit")] int limit = 25,
            [AliasAs("offset")] int offset = 0,
            [Header("X-WSO2-Tenant")] string tenant = ""
            );

        //Get a document
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/apis/{apiId}/documents/{documentId}")]
        Task<ApiResponse<Document>> GetDocument(
            [AliasAs("apiId")] string apiId,
            [AliasAs("documentId")] string documentId,
            [Header("X-WSO2-Tenant")] string tenant = ""
            );

        //Get the content of a document
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/apis/{apiId}/documents/{documentId}/content")]
        Task<ApiResponse<string>> GetDocumentContent(
            [AliasAs("apiId")] string apiId,
            [AliasAs("documentId")] string documentId,
            [Header("X-WSO2-Tenant")] string tenant = ""
            );
    }
}
