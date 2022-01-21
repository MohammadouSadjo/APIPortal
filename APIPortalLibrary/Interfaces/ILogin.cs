using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models;

namespace APIPortalLibrary.Interfaces
{
    interface ILogin
    {
        //Get access token
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        [Post("/oauth2/token")]
        Task<ApiResponse<AccessToken>> GetAccessToken(
            [Header("Authorization")] string authorization,
            [AliasAs("username")] string username,
            [AliasAs("password")] string password,
            [AliasAs("grant_type")] string grant_type = "password",
            [AliasAs("scope")] string scope = "apim:subscribe"
            );

        //Get clienId and secretId
        [Headers("Content-Type: application/json")]
        [Post("/client-registration/v0.14/register")]
        Task<ApiResponse<ClientIDAndSecret>> GetClientIDSecret(
            [Header("Authorization")] string authorization,
            [Body] string body
            );
    }
}
