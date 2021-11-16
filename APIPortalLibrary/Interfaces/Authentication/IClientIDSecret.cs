using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models.Authentication;

namespace APIPortalLibrary.Interfaces.Authentication
{
    interface IClientIDSecret
    {
        [Headers("Content-Type: application/json", "Authorization: Basic YWRtaW46YWRtaW4=")]
        [Post("/client-registration/v0.14/register")]
        Task<ClientIDSecret> GetClientIDSecret(
            [Body] string body
            );
    }
}
