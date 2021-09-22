using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.Models
{
    public class Value
    {
        public string id { get; set; }
        public string correlationId { get; set; }
        public string userId { get; set; }
        public string userPrincipalName { get; set; }
        public string userDisplayName { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime inviteDateTime { get; set; }
        public DateTime failureDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public int duration { get; set; }
        public string callType { get; set; }
        public bool successfulCall { get; set; }
        public string callerNumber { get; set; }
        public string calleeNumber { get; set; }
        public string mediaPathLocation { get; set; }
        public string signalingLocation { get; set; }
        public int finalSipCode { get; set; }
        public int callEndSubReason { get; set; }
        public string finalSipCodePhrase { get; set; }
        public string trunkFullyQualifiedDomainName { get; set; }
        public bool mediaBypassEnabled { get; set; }
    }

    public class Root
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("@odata.count")]
        public int OdataCount { get; set; }
        public List<Value> value { get; set; }
    }
}
