using BillingPortal.Models;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace BillingPortal.Helpers
{

    public static class CreateNewSubscription
    {
        public static readonly ITokenAcquisition tokenAcquisition;

        public static async System.Threading.Tasks.Task FetchData()
        {

            try
            {
               await GetRecordsAsync();
            }
            catch (Exception e)
            {
                var s = e;

            }


        }
        public static async Task<string> GetRecordsAsync()
        {
            try
            {
                var Accesstoken = await AuthenticateOutboundRequestAsync("a5ec227e-1161-487d-8e4b-168353d1a844", "961c04f4-9003-4613-8b85-cabd4989e8e5", "RWQ7Q~umhGx7rWHcpIrUaKw14UO5PAO94YFjc");
                var GetToken = JsonConvert.DeserializeObject<Token>(Accesstoken);

                var client = new RestClient("https://graph.microsoft.com/beta/communications/callRecords/getDirectRoutingCalls(fromDateTime=" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + ",toDateTime=" + DateTime.Now.ToString("yyyy-MM-dd") + ")")
                {
                    Timeout = -1
                };
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + GetToken.access_token);
                request.AddParameter("text/plain", "", ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);
                var ConvertData = JsonConvert.DeserializeObject<Models.Root>(response.Content);
                foreach (var item in ConvertData.value)
                {
                    SaveCall(item.correlationId, GetToken.access_token);


                }
                return response.Content;
            }
            catch (Exception ex)
            {
                return null;

            }


        }
        public static async void SaveCall(string id, string access_token)
        {


            var GetInformation = await GetCallInformationAsync(access_token, id);
            var ConvertData = JsonConvert.DeserializeObject<Records>(GetInformation);
            if (ConvertData.Sessions != null)
            {
                using(DatabaseContext databaseContext = new DatabaseContext()) { 
                var Sessions = ConvertData.Sessions.FirstOrDefault();
                try
                {
                    if (databaseContext.recordsTables.Where(x => x.RecoredId == ConvertData.Id).FirstOrDefault() == null)
                    {
                        var TotalTime = ConvertData.EndDateTime - ConvertData.StartDateTime;

                        if (Sessions.Callee.UserAgent.Platform != "unknown")
                        {
                            if (Sessions.Caller.UserAgent.Platform != "unknown")
                            {
                                RecordsTable recordsTable = new RecordsTable()
                                {
                                    ID = Guid.NewGuid(),

                                    RecoredId = ConvertData.Id,
                                    type = ConvertData.Type,
                                    startDateTime = ConvertData.StartDateTime,
                                    endDateTime = ConvertData.EndDateTime,
                                    CalleeId = Sessions?.Callee?.Identity?.User?.Id ?? Guid.Empty,
                                    CalleeName = Sessions?.Callee?.Identity?.User?.DisplayName ?? "",
                                    CalleeTanent = Sessions?.Callee?.Identity?.User?.TenantId ?? Guid.Empty,
                                    CallerId = Sessions?.Caller?.Identity?.User?.Id ?? Guid.Empty,
                                    Phone = false,
                                    CallerName = Sessions?.Caller?.Identity?.User?.DisplayName ?? "",
                                    CallerTanent = Sessions?.Caller?.Identity?.User?.TenantId ?? Guid.Empty,
                                    SessionCalleePlatform = Sessions?.Callee?.UserAgent?.Platform ?? "",
                                    SessionCalleeProductFamily = Sessions?.Callee?.UserAgent?.ProductFamily ?? "",
                                    SessionCallerPlatform = Sessions?.Caller?.UserAgent?.Platform ?? "",
                                    SessionCallerProductFamily = Sessions?.Caller?.UserAgent?.ProductFamily ?? "",
                                    TotalTime = TotalTime.TotalSeconds,
                                    dnsSuffix = Sessions?.Segments?.FirstOrDefault()?.Media?.FirstOrDefault()?.CallerNetwork?.DnsSuffix ?? "",
                                    ReflexiveIPAddress = Sessions?.Segments?.FirstOrDefault()?.Media?.FirstOrDefault()?.CallerNetwork?.ReflexiveIpAddress ?? "",

                                };
                                databaseContext.recordsTables.Add(recordsTable);
                            }
                            else
                            {
                                var GetCaldulcatedData = CalculateCall(Sessions?.Caller?.Identity?.Phone?.Id, TotalTime, databaseContext);
                                RecordsTable recordsTable = new RecordsTable()
                                {
                                    ID = Guid.NewGuid(),
                                    RecoredId = ConvertData.Id,
                                    type = ConvertData.Type,
                                    startDateTime = ConvertData.StartDateTime,
                                    endDateTime = ConvertData.EndDateTime,
                                    Phone = false,
                                    IncomingPhone = true,
                                    CallerNumber = Sessions?.Callee?.Identity?.Phone?.Id?.ToString() ?? "",
                                    CallerId = Guid.Empty,
                                    CallerName = Sessions?.Callee?.Identity?.Phone?.DisplayName ?? "",
                                    CallerTanent = Guid.Empty,
                                    CalleeId = Sessions?.Caller?.Identity?.User?.Id ?? Guid.Empty,
                                    CalleeName = Sessions?.Caller?.Identity?.User?.DisplayName ?? "",
                                    CalleeTanent = Sessions?.Caller?.Identity?.User?.TenantId ?? Guid.Empty,
                                    SessionCalleePlatform = Sessions?.Callee?.UserAgent?.Platform ?? "",
                                    SessionCalleeProductFamily = Sessions?.Callee?.UserAgent?.ProductFamily ?? "",
                                    SessionCallerPlatform = Sessions?.Caller?.UserAgent?.Platform ?? "",
                                    SessionCallerProductFamily = Sessions?.Caller?.UserAgent?.ProductFamily ?? "",
                                    TotalTime = TotalTime.TotalSeconds,
                                    Country = GetCaldulcatedData.Country,
                                    TotalCost = GetCaldulcatedData.totalamount,
                                    dnsSuffix = Sessions?.Segments?.FirstOrDefault()?.Media?.FirstOrDefault()?.CallerNetwork?.DnsSuffix ?? "",
                                    ReflexiveIPAddress = Sessions?.Segments?.FirstOrDefault()?.Media?.FirstOrDefault()?.CallerNetwork?.ReflexiveIpAddress ?? "",

                                };
                                databaseContext.recordsTables.Add(recordsTable);
                            }
                        }
                        else
                        {
                            if (Sessions.Caller.UserAgent.Platform != "unknown")
                            {
                                if (Sessions.Callee.Identity.User == null)
                                {
                                        var GetCaldulcatedData = CalculateCall(Sessions?.Callee?.Identity?.Phone?.Id, TotalTime, databaseContext);
                                        RecordsTable recordsTable = new RecordsTable()
                                    {
                                        ID = Guid.NewGuid(),

                                        RecoredId = ConvertData.Id,
                                        type = ConvertData.Type,
                                        startDateTime = ConvertData.StartDateTime,
                                        endDateTime = ConvertData.EndDateTime,
                                        CalleeNumber = Sessions?.Callee?.Identity?.Phone?.Id?.ToString() ?? "",
                                        CalleeId = Guid.Empty,
                                        CalleeName = Sessions?.Callee?.Identity?.Phone?.DisplayName ?? "",
                                        CalleeTanent = Guid.Empty,
                                        Phone = true,
                                        CallerName = Sessions?.Caller?.Identity?.User?.DisplayName ?? "",
                                        CallerTanent = Sessions?.Caller?.Identity?.User?.TenantId ?? Guid.Empty,
                                        SessionCalleePlatform = Sessions?.Callee?.UserAgent?.Platform ?? "",
                                        SessionCalleeProductFamily = Sessions?.Callee?.UserAgent?.ProductFamily ?? "",
                                        SessionCallerPlatform = Sessions?.Caller?.UserAgent?.Platform ?? "",
                                        SessionCallerProductFamily = Sessions?.Caller?.UserAgent?.ProductFamily ?? "",
                                        TotalTime = TotalTime.TotalSeconds,
                                            Country = GetCaldulcatedData.Country,
                                            TotalCost = GetCaldulcatedData.totalamount,
                                            dnsSuffix = Sessions?.Segments?.FirstOrDefault()?.Media?.FirstOrDefault()?.CallerNetwork?.DnsSuffix ?? "",
                                        ReflexiveIPAddress = Sessions?.Segments?.FirstOrDefault()?.Media?.FirstOrDefault()?.CallerNetwork?.ReflexiveIpAddress ?? "",


                                    };
                                    databaseContext.recordsTables.Add(recordsTable);
                                }
                                else
                                {
                                    if (Sessions.Callee.Identity.User == null)
                                    {
                                        RecordsTable recordsTable = new RecordsTable()
                                        {
                                            ID = Guid.NewGuid(),

                                            RecoredId = ConvertData.Id,
                                            type = ConvertData.Type,
                                            startDateTime = ConvertData.StartDateTime,
                                            endDateTime = ConvertData.EndDateTime,
                                            CalleeId = Sessions?.Callee?.Identity?.User?.Id ?? Guid.Empty,
                                            CalleeName = Sessions?.Callee?.Identity?.User?.DisplayName ?? "",
                                            CalleeTanent = Sessions?.Callee?.Identity?.User?.TenantId ?? Guid.Empty,
                                            CallerId = Sessions?.Caller?.Identity?.User?.Id ?? Guid.Empty,
                                            Phone = false,
                                            CallerName = Sessions?.Caller?.Identity?.User?.DisplayName ?? "",
                                            CallerTanent = Sessions?.Caller?.Identity?.User?.TenantId ?? Guid.Empty,
                                            SessionCalleePlatform = Sessions?.Callee?.UserAgent?.Platform ?? "",
                                            SessionCalleeProductFamily = Sessions?.Callee?.UserAgent?.ProductFamily ?? "",
                                            SessionCallerPlatform = Sessions?.Caller?.UserAgent?.Platform ?? "",
                                            SessionCallerProductFamily = Sessions?.Caller?.UserAgent?.ProductFamily ?? "",
                                            TotalTime = TotalTime.TotalSeconds,
                                            dnsSuffix = Sessions?.Segments?.FirstOrDefault()?.Media?.FirstOrDefault()?.CallerNetwork?.DnsSuffix ?? "",
                                            ReflexiveIPAddress = Sessions?.Segments?.FirstOrDefault()?.Media?.FirstOrDefault()?.CallerNetwork?.ReflexiveIpAddress ?? "",


                                        };
                                        databaseContext.recordsTables.Add(recordsTable);
                                    }
                                }


                            }
                            else
                            {

                                var GetCaldulcatedData = CalculateCall(Sessions?.Callee?.Identity?.Phone?.Id, TotalTime, databaseContext);
                                RecordsTable recordsTable = new RecordsTable()
                                {
                                    ID = Guid.NewGuid(),
                                    RecoredId = ConvertData.Id,
                                    type = ConvertData.Type,
                                    startDateTime = ConvertData.StartDateTime,
                                    endDateTime = ConvertData.EndDateTime,
                                    Phone = true,
                                    CalleeNumber = Sessions?.Callee?.Identity?.Phone?.Id?.ToString() ?? "",
                                    CalleeId = Guid.Empty,
                                    CalleeName = Sessions?.Callee?.Identity?.Phone?.DisplayName ?? "",
                                    CalleeTanent = Guid.Empty,
                                    CallerId = Sessions?.Caller?.Identity?.User?.Id ?? Guid.Empty,
                                    CallerName = Sessions?.Caller?.Identity?.User?.DisplayName ?? "",
                                    CallerTanent = Sessions?.Caller?.Identity?.User?.TenantId ?? Guid.Empty,
                                    SessionCalleePlatform = Sessions?.Callee?.UserAgent?.Platform ?? "",
                                    SessionCalleeProductFamily = Sessions?.Callee?.UserAgent?.ProductFamily ?? "",
                                    SessionCallerPlatform = Sessions?.Caller?.UserAgent?.Platform ?? "",
                                    SessionCallerProductFamily = Sessions?.Caller?.UserAgent?.ProductFamily ?? "",
                                    TotalTime = TotalTime.TotalSeconds,
                                    Country = GetCaldulcatedData.Country,
                                    TotalCost = GetCaldulcatedData.totalamount,
                                    dnsSuffix = Sessions?.Segments?.FirstOrDefault()?.Media?.FirstOrDefault()?.CallerNetwork?.DnsSuffix ?? "",
                                    ReflexiveIPAddress = Sessions?.Segments?.FirstOrDefault()?.Media?.FirstOrDefault()?.CallerNetwork?.ReflexiveIpAddress ?? "",

                                };
                                databaseContext.recordsTables.Add(recordsTable);

                            }

                        }
                      await  databaseContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {



                }
                }
            }

        }


        public static async Task<string> AuthenticateOutboundRequestAsync(string TenatID, string ClientID, string ClientSecret)
        {
            try
            {
                var client = new RestClient("https://login.microsoftonline.com/" + TenatID + "/oauth2/v2.0/token");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Cookie", "x-ms-gateway-slice=estsfd; stsservicecookie=estsfd; fpc=AoM0xEFcWYJNjc0RXZQvPM2m5zo5AQAAAIv3ZtYOAAAA");
                request.AddParameter("grant_type", "client_credentials");
                request.AddParameter("client_id", ClientID);
                request.AddParameter("client_secret", ClientSecret);
                request.AddParameter("scope", "https://graph.microsoft.com/.default");
                IRestResponse response = await client.ExecuteAsync(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static CalculatedData CalculateCall(string Phone, TimeSpan TotalTime, DatabaseContext databaseContext)
        {
     
                try
                {
                    var Country = string.Empty;
                    var GetuserCountryCode = Phone.Substring(0, 5);
                    GetuserCountryCode = GetuserCountryCode.Replace("+", "");
                    var CallCountryTable = databaseContext.country.ToList();
                    var FirstCheckValue = Phone.Substring(0, 3);
                    var ScoundCheckValue = Phone.Substring(0, 4);
                    var ConvertFirstValue = Convert.ToInt32(FirstCheckValue);
                    var ConvertScoundValue = Convert.ToInt32(ScoundCheckValue);
                    var ConvertThirdValue = Convert.ToInt32(GetuserCountryCode);
                    double? TotalCost = 0.0;
                    var StartCount = 0;
                    var countrydata = new country();
                    if (CallCountryTable.Where(x => x.phonecode == ConvertFirstValue).FirstOrDefault() != null)
                    {
                        countrydata = CallCountryTable.Where(x => x.phonecode == ConvertFirstValue).FirstOrDefault();
                        StartCount = 3;
                    }
                    if (CallCountryTable.Where(x => x.phonecode == ConvertScoundValue).FirstOrDefault() != null)
                    {
                        countrydata = CallCountryTable.Where(x => x.phonecode == ConvertScoundValue).FirstOrDefault();
                        StartCount = 4;
                    }
                    if (CallCountryTable.Where(x => x.phonecode == ConvertThirdValue).FirstOrDefault() != null)
                    {
                        countrydata = CallCountryTable.Where(x => x.phonecode == ConvertThirdValue).FirstOrDefault();
                        StartCount = 5;
                    }
                    double? totalamount = 0.0;
                    if (countrydata != null)
                    {
                        if (countrydata.SubPhones == true)
                        {
                            var GetSubCountryPhones = databaseContext.SubPhones.Where(x => x.CountryID == countrydata.id).ToList();
                            foreach (var item in GetSubCountryPhones)
                            {
                                var CheckValue = Phone.Substring(StartCount, item.phonecode.ToString().Length);
                                if (CheckValue == item.phonecode.ToString())
                                {
                                    Country = countrydata.countryname ?? "";
                                    if (item.PerMinute)
                                    {
                                        TotalCost = item.CostPerMinute ?? 0.0;
                                        if (TotalCost != null)
                                        {
                                            totalamount = Math.Ceiling(TotalTime.TotalMinutes) * TotalCost;
                                        }
                                    }
                                    if (item.PerSecond)
                                    {
                                        TotalCost = item.CostPerMinute ?? 0.0;
                                        if (TotalCost != null)
                                        {
                                            totalamount = TotalTime.TotalSeconds * TotalCost;
                                        }
                                    }
                                }


                            }

                        }
                        else
                        {

                            Country = countrydata.countryname ?? "";
                            TotalCost = countrydata.CostPerMinute ?? 0.0;
                            if (countrydata.PerMinute)
                            {
                                TotalCost = countrydata.CostPerMinute ?? 0.0;
                                if (TotalCost != null)
                                {
                                    totalamount = Math.Ceiling(TotalTime.TotalMinutes) * TotalCost;
                                }
                            }
                            if (countrydata.PerSecond)
                            {
                                TotalCost = countrydata.CostPerMinute ?? 0.0;
                                if (TotalCost != null)
                                {
                                    totalamount = TotalTime.TotalSeconds * TotalCost;
                                }
                            }
                        }
                    }


                    return new CalculatedData()
                    {
                        Country = Country,
                        totalamount = totalamount

                    };
                }
                catch (Exception ex)
                {
                    return null;
                }
            
        }

        public static async Task<string> GetCallInformationAsync(string token, string resource)
        {
            try
            {
                var client = new RestClient("https://graph.microsoft.com/v1.0/communications/callRecords/" + resource + "?$expand=sessions($expand=segments)")
                {
                    Timeout = -1
                };
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("text/plain", "", ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);
                return response.Content;
            }
            catch (Exception ex)
            {
                return null;

            }


        }
    }
    public class CalculatedData
    {

        public string Country { get; set; }
        public double? totalamount { get; set; }
    }
}
