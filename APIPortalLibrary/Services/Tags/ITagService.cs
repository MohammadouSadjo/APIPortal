using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Tags
{
    public interface ITagService
    {
        Task<ApiResponse<AllTags>> Alltags(int limit = 25, int offset = 0);//Get List of all Tags
        void SetBaseAdress(Uri uri);
    }
}
