using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models.Store
{
    public class ApplicationKeys
    {
        public string consumerSecret { get; set; }
        public string consumerKey { get; set; }
        public string keystate { get; set; }
        public string keyType { get; set; }
        public List<string> supportedGrantTypes { get; set; }
        public AToken token { get; set; }
    }

    public class AToken
    {
        public int validityTime { get; set; }
        public string accessToken { get; set; }
        public List<string> tokenScopes { get; set; }
    }
}
