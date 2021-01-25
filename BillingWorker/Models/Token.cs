using System;
using System.Collections.Generic;
using System.Text;

namespace BillingWorker.Models
{
    public class Token
    {
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string ext_expires_in { get; set; }
        public string access_token { get; set; }
    }
}
