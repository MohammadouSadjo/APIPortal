﻿using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models
{
    public class AllApis
    {
        public int count { get; set; }
        public List<API> list { get; set; }
        public Pagination pagination { get; set; }
    }
    public class API
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string context { get; set; }
        public string version { get; set; }
        public string type { get; set; }
        public string provider { get; set; }
        public string lifeCycleStatus { get; set; }
        public string avgRating { get; set; }
        public List<string> throttlingPolicies { get; set; }
        public AdvertiseInfo advertiseInfo { get; set; }
        public BusinessInformation businessInformation { get; set; }
        public bool isSubscriptionAvailable { get; set; }
        public string monetizationLabel { get; set; }
        public bool isDefaultVersion { get; set; }
        public string thumbnailUri { get; set; }
        public List<string> transport { get; set; }
        public string authorizationHeader { get; set; }
        public List<string> tags { get; set; }
        public List<string> tiers { get; set; }
        public List<EndpointURL> endpointURLs { get; set; }
        public List<string> environmentList { get; set; }
        public string lastUpdatedTime { get; set; }
        public string createdTime { get; set; }
        public List<string> scopes { get; set; }
    }

    public class Pagination
    {
        public int total { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
    }

    public class EndpointURL
    {
        public string environmentName { get; set; }
        public string environmentType { get; set; }
        public EnvironmentURL environmentURLs { get; set; }
    }

    public class EnvironmentURL
    {
        public string http { get; set; }
        public string https { get; set; }
    }

    public class BusinessInformation
    {
        public string technicalOwnerEmail { get; set; }
        public string businessOwnerEmail { get; set; }
        public string businessOwner { get; set; }
        public string technicalOwner { get; set; }
    }

    public class AdvertiseInfo
    {
        public bool advertised { get; set; }
        public string originalDevPortalUrl { get; set; }
        public string apiOwner { get; set; }
        public string vendor { get; set; }
    }
}
