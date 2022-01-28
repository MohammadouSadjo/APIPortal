using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Login
{
    public interface IClientIdAndSecretService
    {
        Task<ApiResponse<ClientIDAndSecret>> ClientIDSecret(string username, string password, string callbackUrl, string clientName, string owner, string grantType, bool saasApp);//Get clientId and SecretId
        void SetBaseAdress(Uri uri);
    }
}
