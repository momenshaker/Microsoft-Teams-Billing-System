using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.Models
{
    public class SystemSetting
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Version{ get; set; }
        public string TID { get; set; }
        public string OID { get; set; }
        public string Sec { get; set; }

        public string AID { get; set; }
    }
}
