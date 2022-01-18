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
        Task<ApiResponse<AllApis>> AllApis(int limit = 25, int offset = 0, string query = "");//Get all APIs
        Task<ApiResponse<API>> APIDetails(string apiId);//Get API Details
        Task<ApiResponse<string>> SwaggerDefinition(string apiId);//Get Swagger definition of an API
    }
}
