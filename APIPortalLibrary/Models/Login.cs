using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models
{
    public class Login
    {
    }

    public class ClientIDAndSecret
    {
        public string clientId { get; set; }
        public string clientSecret { get; set; }
    }

    public class AccessToken
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}
