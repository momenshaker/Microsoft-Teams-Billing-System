using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.Models
{
    public class CompanyServers
    {
        public Guid id { get; set; }
        public string ServerName { get; set; }
        public string ServerIP { get; set; }
        public string Location { get; set; }

    }
}
