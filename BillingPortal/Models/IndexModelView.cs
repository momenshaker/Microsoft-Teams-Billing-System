using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.Models
{
    public class IndexModelView
    {
        public int TotalCalls { get; set; }
        public double AvarageCallTime { get; set; }
        public double TotalCallTime { get; set; }
        public string LastMonthAvarageTime { get; set; }
        public string LastMonthcalls { get; set; }
        public Dictionary<string, string> TimeChart { get; set; }
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
        public string LatestUpdate { get; set; }
    }
    public class IntItems
    {
        public int Value { get; set; }
        public string Text { get; set; }

    }
    public class DecimalItems
    {
        public double Value { get; set; }
        public string Text { get; set; }

    }
    public class StringItems
    {
        public string Value { get; set; }
        public string Text { get; set; }

    }
}
