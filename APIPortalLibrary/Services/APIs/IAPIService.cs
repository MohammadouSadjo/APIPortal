using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.APIs
{
    public interface IAPIService
    {
        Task<ApiResponse<AllApis>> AllApis(int limit = 25, int offset = 0, string query = "");
        Task<ApiResponse<API>> APIDetails(string apiId);
        Task<ApiResponse<string>> SwaggerDefinition(string apiId);
    }
}
