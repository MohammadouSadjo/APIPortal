using System;
using System.Collections.Generic;
using System.Text;

namespace APIPortalLibrary.Models
{
    public class Subscription
    {
        public string subscriptionId { get; set; }
        public string applicationId { get; set; }
        public string apiId { get; set; }
        public API apiInfo { get; set; }
        public Application applicationInfo { get; set; }
        public string throttlingPolicy { get; set; }
        public string requestedThrottlingPolicy { get; set; }
        public string redirectionParams { get; set; }
        public string status { get; set; }
    }

    public class AllSubscriptions
    {
        public int count { get; set; }
        public Pagination pagination { get; set; }
        public List<Subscription> list { get; set; }
    }
}
