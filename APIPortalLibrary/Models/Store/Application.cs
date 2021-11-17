﻿using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models.Store
{
    public class Application
    {
        public string groupId { get; set; }
        public string callbackUrl { get; set; }
        public string subscriber { get; set; }
        public string throttlingTier { get; set; }
        public string applicationId { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string name { get; set; }
        public string tokenType { get; set; }
        public List<Key> keys { get; set; }
    }

    public class Key
    {
        public string consumerKey { get; set; }
        public string consumerSecret { get; set; }
        public string keyState { get; set; }
        public string keyType { get; set; }
        public List<string> supportedGrantTypes { get; set; }
        public string callbackUrl { get; set; }
        public Token token { get; set; }
    }

    public class Token
    {
        //public int validityTime { get; set; }
        public string accessToken { get; set; }
        public List<string> tokenScopes { get; set; }
    }

    public class GenerateApplicationKeys
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
