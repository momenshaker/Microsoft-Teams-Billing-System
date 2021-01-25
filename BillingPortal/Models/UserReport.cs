using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.Models
{
    public class UserReport
    {
        public int TotalCalls { get; set; }
        public double AvarageCallTime { get; set; }
        public double TotalCallTime { get; set; }
        public List<RecordsTable> RecordsTable { get; set; }
        public List<IntItems> DevicesUses { get; set; }
        public List<DecimalItems> MostPersonUsage { get; set; }
        public List<DecimalItems> MostPersonUsageInternal { get; set; }
        public List<DecimalItems> MostPersonUsageCost { get; set; }
        public List<IntItems> TotalCountriesCalls { get; set; }
        public List<DecimalItems> TotalCountriesCallsTime { get; set; }
        public List<RecordsTable> InternalCalls { get; set; }
        public List<DecimalItems> MapData { get; set; }
        public List<RecordsTable> OutgoingCalls { get; set; }
        public double? TotalCost { get; set; }
    }
}
