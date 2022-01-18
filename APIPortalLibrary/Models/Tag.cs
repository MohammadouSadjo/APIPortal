using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models
{
    public class Tag
    {
        public string name { get; set; }
        public int weight { get; set; }
    }

    public class AllTags
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Tag> list { get; set; }
    }
}
