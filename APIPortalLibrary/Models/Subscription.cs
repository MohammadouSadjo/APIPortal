using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models
{
    public class Subscription
    {
        public string subscriptionId { get; set; }
        public string applicationId { get; set; }
        public string apiIdentifier { get; set; }
        public string tier { get; set; }
        public string status { get; set; }
    }

    public class AllSubscriptions
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Subscription> list { get; set; }
    }
}
