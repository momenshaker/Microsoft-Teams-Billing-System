using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemV4.Models
{
    public class country
    {
        public int id { get; set; }
        public string iso { get; set; }
        public string countryname { get; set; }
        public string nicename { get; set; }
        public string iso3 { get; set; }
        public int? numcode { get; set; }
        public int? phonecode { get; set; }
        public bool SubPhones { get; set; }
        public double? CostPerMinute { get; set; }
        public bool PerMinute { get; set; }
        public bool PerSecond { get; set; }
    }
    public class SubPhones
    {
        public Guid id { get; set; }
        public int CountryID { get; set; }
        public string ProviderName { get; set; }
        public int? phonecode { get; set; }
        public double? CostPerMinute { get; set; }
        public bool PerMinute { get; set; }
        public bool PerSecond { get; set; }
        public Guid Server { get; set; }
        public string ServerName { get; set; }

    }
}
