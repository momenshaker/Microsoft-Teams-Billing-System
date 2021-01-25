using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemV4.Models
{
    public class SubscriptionChecker
    {
        public Guid Id { get; set; }
        public string ValidateToken { get; set; }
        public DateTime CheckedOn { get; set; }
    }
}
