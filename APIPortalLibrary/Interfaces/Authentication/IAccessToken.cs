using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models.Authentication;

namespace APIPortalLibrary.Interfaces.Authentication
{
    interface IAccessToken
    {
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        [Post("/token")]
        Task<AccessToken> GetAccessToken(
            [Header("Authorization")] string authorization,
            [AliasAs("grant_type")] string grant_type,
            [AliasAs("username")] string username,
            [AliasAs("password")] string password,
            [AliasAs("scope")] string scope
            
            );
    }
}
