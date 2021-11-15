using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models.Store
{
    public class AllApis
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
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
        public string provider { get; set; }
        public string status { get; set; }
        public string thumbnailUri { get; set; }
        public List<string> scopes { get; set; }
    }

    public class Pagination
    {
        public int total { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }
}
