using APIPortalLibrary.Interfaces;
using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Documents
{
    public class DocumentService : IDocumentService
    {
        private HttpClient _client;

        public DocumentService(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResponse<AllDocuments>> AllDocuments(string apiId, int limit = 25, int offset = 0, string tenant = "")//Get all documents of a given API
        {
            try
            {
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var allDocuments = await _restApiService.GetAllDocuments(apiId, limit, offset, tenant);

                return allDocuments;
            }
            catch (ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }

        }

        public async Task<ApiResponse<Document>> GetDocument(string apiId, string documentId, string tenant = "")//Get a document
        {
            try
            {
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var document = await _restApiService.GetDocument(apiId, documentId, tenant);

                return document;
            }
            catch (ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }

        }

        public async Task<ApiResponse<string>> GetDocumentContent(string apiId, string documentId, string tenant = "")//Get the content of a given document
        {
            try
            {
                IDocument _restApiService = RestService.For<IDocument>(_client);

                var documentContent = await _restApiService.GetDocumentContent(apiId, documentId, tenant);

                return documentContent;
            }
            catch (ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }

        }
    }
}
