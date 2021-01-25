using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemV4.Models
{
    public class NotificationModel
    {
        public value[] value { get; set; }

    }
    public class value
    {

        public Guid subscriptionId { get; set; }
        public string clientState { get; set; }
        public string changeType { get; set; }
        public string resource { get; set; }
        public string subscriptionExpirationDateTime { get; set; }
        public resourceData resourceData { get; set; }
        public Guid tenantId { get; set; }
    }
    public class resourceData
    {

        public string oDataType { get; set; }
        public string oDataId { get; set; }
        public string Id { get; set; }

    }
}
