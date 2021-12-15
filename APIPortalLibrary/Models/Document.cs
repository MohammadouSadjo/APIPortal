using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models
{
    public class Document
    {
        public string documentId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string summary { get; set; }
        public string sourceType { get; set; }
        public string sourceUrl { get; set; }
        public string otherTypeName { get; set; }
    }

    public class AllDocuments
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Document> list { get; set; }
    }
}
