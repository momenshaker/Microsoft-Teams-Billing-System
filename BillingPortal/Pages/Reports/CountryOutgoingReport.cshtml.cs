using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BillingPortal.Pages.Reports
{
    public class CountryOutgoingReportModel : PageModel
    {
        private readonly ILogger<CountryOutgoingReportModel> _logger;
        private readonly DatabaseContext _context;

        public CountryOutgoingReportModel(ILogger<CountryOutgoingReportModel> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public UserReport _UserReport { get; set; }
        public void OnGet(string id)
        {
            var ConvertID = id.Replace("-", " ");
            var GetAllRecords = _context.recordsTables.Where(x => x.Country == ConvertID).ToList();
            var TotalcallingTime = GetAllRecords.Where(x => x.Phone == true).Select(x => x.TotalTime).ToList().Sum();
            var TotalCalls = GetAllRecords.Where(x => x.Phone == true).Count();
            var Last10Calls = GetAllRecords.OrderBy(x => x.endDateTime).Take(10).ToList();
            var GetDevices = GetAllRecords.Select(x => x.SessionCalleePlatform).Distinct();
            var AvarageCallTime = TotalcallingTime / TotalCalls;
            List<IntItems> Devices = new List<IntItems>();
            foreach (var item in GetDevices)
            {
                var GetTotalUses = GetAllRecords.Where(x => x.SessionCalleePlatform == item).Count();
                Devices.Add(new IntItems() { Value = GetTotalUses, Text = item });
            }
            var GetCallByCountry = GetAllRecords.Where(x => x.Phone == true).Select(x => x.Country).Distinct();
            List<IntItems> CallByCountry = new List<IntItems>();
            List<DecimalItems> CallByCountryTime = new List<DecimalItems>();
            List<DecimalItems> Map = new List<DecimalItems>();
            foreach (var item in GetCallByCountry)
            {
                var GetTotalUsesByCountryTime = GetAllRecords.Where(x => x.Phone == true).Select(x => x.TotalTime).ToList().Sum();
                var GetTotalUsesByCountry = GetAllRecords.Where(x => x.Country == item && x.Phone == true).Count();
                CallByCountry.Add(new IntItems() { Value = GetTotalUsesByCountry, Text = item });
                CallByCountryTime.Add(new DecimalItems() { Value = GetTotalUsesByCountryTime, Text = item });
                var GetCountryCode = _context.country.Where(x => x.countryname == item).FirstOrDefault();
                Map.Add(new DecimalItems() { Value = GetTotalUsesByCountry, Text = GetCountryCode.iso.ToLower() });
            }

            var GetByUser = GetAllRecords.Select(x => x.CallerName).Distinct();
            List<DecimalItems> InternalUsers = new List<DecimalItems>();
            foreach (var item in GetByUser)
            {
                var GetTotalUses = GetAllRecords.Where(x => x.CallerName == item && x.Phone == false).Select(x => x.TotalTime).ToList().Sum();
                InternalUsers.Add(new DecimalItems() { Value = GetTotalUses, Text = item });
            }
            List<DecimalItems> ByUser = new List<DecimalItems>();
            List<DecimalItems> ByUserCost = new List<DecimalItems>();
            foreach (var item in GetByUser)
            {
                var GetTotalUses = GetAllRecords.Where(x => x.CallerName == item && x.Phone == true).Select(x => x.TotalTime).ToList().Sum();
                var GetTotalUsesCost = GetAllRecords.Where(x => x.CallerName == item && x.Phone == true).Select(x => x.TotalCost).ToList().Sum();
                ByUser.Add(new DecimalItems() { Value = GetTotalUses, Text = item });
                ByUserCost.Add(new DecimalItems() { Value = Convert.ToDouble(GetTotalUsesCost), Text = item });
            }
            _UserReport = new UserReport
            {
                AvarageCallTime = Math.Round(AvarageCallTime, 2),
                DevicesUses = Devices.OrderBy(x => x.Value).Take(4).ToList(),
                MostPersonUsage = ByUser,
                RecordsTable = Last10Calls,
                TotalCalls = TotalCalls,
                TotalCallTime = Math.Round(TotalcallingTime, 2),
                TotalCountriesCalls = CallByCountry,
                TotalCountriesCallsTime = CallByCountryTime,
                MostPersonUsageInternal = InternalUsers,
                InternalCalls = GetAllRecords.Where(x => x.Phone == false).OrderByDescending(x => x.endDateTime).ToList(),
                OutgoingCalls = GetAllRecords.Where(x => x.Phone == true).OrderByDescending(x => x.endDateTime).ToList(),
                MapData = Map,
                TotalCost = GetAllRecords.Where(x => x.TotalTime >= 1.0).Select(x => x.TotalCost).Sum(),
                MostPersonUsageCost = ByUserCost
            };

        }
    }
}