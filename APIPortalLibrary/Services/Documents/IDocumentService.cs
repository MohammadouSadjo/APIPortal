using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Documents
{
    public interface IDocumentService
    {
        Task<ApiResponse<AllDocuments>> AllDocuments(string apiId, int limit = 25, int offset = 0, string tenant = "");
        Task<ApiResponse<Document>> GetDocument(string apiId, string documentId, string tenant = "");
        Task<ApiResponse<string>> GetDocumentContent(string apiId, string documentId, string tenant = "");
    }
}
