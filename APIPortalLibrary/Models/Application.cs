using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models
{
    public class Application
    {
        public string throttlingPolicy { get; set; }
        public string applicationId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public int subscriptionCount { get; set; }
        public string owner { get; set; }
        public string tokenType { get; set; }
    }

    public class AllApplications
    {
        public int count { get; set; }
        public Pagination pagination { get; set; }
        public List<Application> list { get; set; }
    }

    public class Key
    {
        public string consumerKey { get; set; }
        public string consumerSecret { get; set; }
        public string keyState { get; set; }
        public string keyType { get; set; }
        public List<string> supportedGrantTypes { get; set; }
        public string callbackUrl { get; set; }
        public string groupId { get; set; }
        public Token token { get; set; }
    }

    public class Token
    {
        public long validityTime { get; set; }
        public string accessToken { get; set; }
        public List<string> tokenScopes { get; set; }
    }

    public class GenerateApplicationKeys
    {
        //public string keyMappingId { get; set; }
        //public string keyManager { get; set; }
        //public string callbackUrl { get; set; }
        //public string mode { get; set; }
        public string consumerSecret { get; set; }
        //public string consumerKey { get; set; }
        //public string keyState { get; set; }
        //public string keyType { get; set; }
        //public List<string> supportedGrantTypes { get; set; }*/
        //public AToken token { get; set; }
        //public AdditionnalProperties additionnalProperties { get; set; }
    }

    public class AToken
    {
        public int validityTime { get; set; }
        public string accessToken { get; set; }
        public List<string> tokenScopes { get; set; }
    }

    public class AdditionnalProperties
    {
        public int id_token_expiry_time { get; set; }
        public int application_access_token_expiry_time { get; set; }
        public int refresh_token_expiry_time { get; set; }
        public int user_access_token_expiry_time { get; set; }
    }
}
