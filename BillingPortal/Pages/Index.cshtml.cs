using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingPortal.Infrasturcture.Interfaces;
using BillingPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BillingPortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DatabaseContext _context;
        private readonly IFetchData _fetchData;

        public IndexModel(ILogger<IndexModel> logger, DatabaseContext context, IFetchData fetchData)
        {
            _logger = logger;
            _context = context;
            _fetchData= fetchData;


        }
        [BindProperty]
        public IndexModelView _IndexModelView { get; set; }

        public void OnGet()
        {
            _fetchData.GetRecordsAsync();

            var peertopeerstring = "peerToPeer";
            var GetAllRecords = _context.recordsTables.Where(x => x.type == peertopeerstring).ToList();
            if (GetAllRecords != null && GetAllRecords.Count != 0)
            {
                var TotalcallingTime = GetAllRecords.Where(x => x.Phone == true).Select(x => x.TotalTime).ToList().Sum();
                var TotalCalls = GetAllRecords.Where(x => x.Phone == true).Count();
                var Last10Calls = GetAllRecords.OrderBy(x => x.endDateTime).Take(10).ToList();
                var AvarageCallTime = TotalcallingTime / TotalCalls;
                var LatestUpdate = GetAllRecords.OrderByDescending(x => x.endDateTime).FirstOrDefault();
                List<IntItems> Devices = new List<IntItems>();
                var GetServers = _context.CompanyServers.ToList();
                foreach (var item in GetServers)
                {

                    var GetTotalUses = GetAllRecords.Where(x => x.ReflexiveIPAddress == item.ServerIP).Count();
                    Devices.Add(new IntItems() { Value = GetTotalUses, Text = item.ServerName });
                }
                var GetCallByCountry = GetAllRecords.Where(x => x.Phone == true).Select(x => x.Country).Distinct();
                List<IntItems> CallByCountry = new List<IntItems>();
                List<DecimalItems> CallByCountryTime = new List<DecimalItems>();
                List<DecimalItems> Map = new List<DecimalItems>();
                foreach (var item in GetCallByCountry)
                {
                    var GetTotalUsesByCountryTime = GetAllRecords.Where(x => x.Phone == true && x.Country == item).Select(x => x.TotalTime).ToList().Sum();
                    var GetTotalUsesByCountry = GetAllRecords.Where(x => x.Country == item && x.Phone == true).Count();
                    CallByCountry.Add(new IntItems() { Value = GetTotalUsesByCountry, Text = item });
                    CallByCountryTime.Add(new DecimalItems() { Value = GetTotalUsesByCountryTime, Text = item });
                    var GetCountryCode = _context.country.Where(x => x.countryname == item).FirstOrDefault();
                    if (GetCountryCode != null)
                    {
                        Map.Add(new DecimalItems() { Value = GetTotalUsesByCountry, Text = GetCountryCode.iso.ToLower() });
                    }
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
                _IndexModelView = new IndexModelView
                {
                    AvarageCallTime = Math.Round(AvarageCallTime, 2),
                    DevicesUses = Devices.OrderBy(x => x.Value).Take(4).ToList(),
                    MostPersonUsage = ByUser.OrderByDescending(x => x.Value).Take(5).ToList(),
                    RecordsTable = Last10Calls.Take(10).ToList(),
                    TotalCalls = TotalCalls,
                    TotalCallTime = Math.Round(TotalcallingTime, 2),
                    TotalCountriesCalls = CallByCountry.OrderByDescending(x => x.Value).Take(5).ToList(),
                    TotalCountriesCallsTime = CallByCountryTime.OrderByDescending(x => x.Value).Take(5).ToList(),
                    MostPersonUsageInternal = InternalUsers.OrderByDescending(x => x.Value).Take(5).ToList(),
                    InternalCalls = GetAllRecords.Where(x => x.Phone == false).OrderByDescending(x => x.endDateTime).Take(5).ToList(),
                    OutgoingCalls = GetAllRecords.Where(x => x.Phone == true).OrderByDescending(x => x.endDateTime).Take(5).ToList(),
                    MapData = Map,
                    TotalCost = GetAllRecords.Select(x => x.TotalCost).Sum(),
                    MostPersonUsageCost = ByUserCost.OrderByDescending(x => x.Value).Take(5).ToList(),
                    LatestUpdate = LatestUpdate.endDateTime.DateTime.ToShortDateString() + "-" + LatestUpdate.endDateTime.DateTime.ToShortTimeString()
                };
            }
            else {
                _IndexModelView = new IndexModelView();
            }

        }
    }
}
