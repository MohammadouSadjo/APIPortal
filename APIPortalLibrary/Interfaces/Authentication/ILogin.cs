﻿using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models.Authentication;

namespace APIPortalLibrary.Interfaces.Authentication
{
    interface ILogin
    {
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        [Post("/token")]
        Task<ApiResponse<AccessToken>> GetAccessToken(
            [Header("Authorization")] string authorization,
            [AliasAs("username")] string username,
            [AliasAs("password")] string password,
            [AliasAs("grant_type")] string grant_type = "password",
            [AliasAs("scope")] string scope = "apim:subscribe"
            );

        [Headers("Content-Type: application/json", "Authorization: Basic YWRtaW46YWRtaW4=")]
        [Post("/client-registration/v0.14/register")]
        Task<ApiResponse<ClientIDAndSecret>> GetClientIDSecret(
            [Body] string body
            );
    }
}
