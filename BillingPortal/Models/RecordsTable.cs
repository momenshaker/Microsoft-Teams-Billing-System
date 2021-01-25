using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.Models
{
    public class RecordsTable
    {
        [Key]
        public Guid ID { get; set; }
        public Guid RecoredId { get; set; }
        public string type { get; set; }
        public DateTimeOffset startDateTime { get; set; }
        public DateTimeOffset endDateTime { get; set; }
        public bool IncomingPhone { get; set; }
        public Guid CallerId { get; set; }
        public string CallerName { get; set; }
        public Guid CallerTanent { get; set; }
        public string CallerNumber { get; set; }
        public bool Phone { get; set; }
        public string CalleeNumber { get; set; }
        public Guid CalleeId { get; set; }
        public string CalleeName { get; set; }
        public Guid CalleeTanent { get; set; }
        public string SessionCallerPlatform { get; set; }
        public string SessionCallerProductFamily { get; set; }
        public string SessionCalleePlatform { get; set; }
        public string SessionCalleeProductFamily { get; set; }
        public double TotalTime { get; set; }
        public string Country { get; set; }
        public double? TotalCost { get; set; }
        public string ReflexiveIPAddress { get; set; }
        public string dnsSuffix { get; set; }

    }
}
