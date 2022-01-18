using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Interfaces
{
    interface ITag
    {
        //Get all Tags
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/tags")]
        Task<ApiResponse<AllTags>> GetAllTags(
            [AliasAs("limit")] int limit = 25,
            [AliasAs("offset")] int offset = 0
            );
    }
}
