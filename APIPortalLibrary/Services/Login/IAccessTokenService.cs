using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Login
{
    public interface IAccessTokenService
    {
        Task<ApiResponse<AccessToken>> AccessToken(string username, string password, string clientId, string clientSecret);//Get access token
        void SetBaseAdress(Uri uri);
    }
}
