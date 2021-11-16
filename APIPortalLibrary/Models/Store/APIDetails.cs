using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models.Store
{
    public class APIDetails
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string context { get; set; }
        public string version { get; set; }
        public string provider { get; set; }
        public string apiDefinition { get; set; }
        public string wsdlUri { get; set; }
        public string status { get; set; }
        public bool isDefaultVersion { get; set; }
        public List<string> transport { get; set; }
        public string authorizationHeader { get; set; }
        public List<string> tags { get; set; }
        public List<string> tiers { get; set; }
        public string thumbnailUrl { get; set; }
        //public string id { get; set; }
        public List<EndpointURL> endpointURLs { get; set; }
        public BusinessInformation businessInformation { get; set; }
        public List<string> labels { get; set; }
        public List<string> environmentList { get; set; }
        public string lastUpdatedTime { get; set; }
        public string createdTTime { get; set; }
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

}
