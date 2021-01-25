
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using BillingPortal.Models;
using BillingPortal.NotificationModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace BillingPortal.Areas.API.Controllers
{
    [Area("API")]
    [AllowAnonymous]
    public class NotifyController : Controller
    {

        private readonly ILogger logger;
        private readonly IOptions<AppSettings> appSettings;
        private readonly IOptions<KeyVaultOptions> KeyVaultOptions; private readonly IOptions<SubscriptionOptions> subscriptionOptions;
        private readonly DatabaseContext databaseContext;
        public NotifyController(ILogger<NotifyController> logger, DatabaseContext _context,
                                  IOptions<AppSettings> appSettings, IOptions<KeyVaultOptions> keyVaultOptions, IOptions<SubscriptionOptions> subscriptionOptions)
        {
            this.databaseContext = _context;
            this.logger = logger;
            this.appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            this.KeyVaultOptions = keyVaultOptions; this.subscriptionOptions = subscriptionOptions ?? throw new ArgumentNullException(nameof(subscriptionOptions));

        }
        public IActionResult Listen()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Listen(string validationToken = null)
        {
            //if (string.IsNullOrEmpty(validationToken))
            //{
            //    try
            //    {
            //        // Parse the received notifications.
            //        var plainNotifications = new List<value>();
            //        var options = new JsonSerializerOptions
            //        {
            //            PropertyNameCaseInsensitive = true
            //        };
            //        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            //        var collection = await System.Text.Json.JsonSerializer.DeserializeAsync<NModel>(Request.Body, options);
            //        foreach (var notification in collection.value)
            //        {
            //            //SubscriptionStore subscription = subscriptionStore.GetSubscriptionInfo(notification.subscriptionId);

            //            //// Verify the current client state matches the one that was sent.
            //            //if (notification.clientState == subscription.ClientState)
            //            //{
            //            // Just keep the latest notification for each resource. No point pulling data more than once.
            //            plainNotifications.Add(notification);
            //            //}
            //        }

            //        if (plainNotifications.Count > 0)
            //        {
            //            // Query for the changed messages. 
            //            await GetChangedMessagesAsync(plainNotifications);
            //        }


            //    }
            //    catch (Exception ex)
            //    {
            //        logger.LogError($"ParsingNotification: { ex.Message }");

            //        // Still return a 202 so the service doesn't resend the notification.
            //    }
            //    return StatusCode(200);
            //}
            //else
            //{
            //    var SubscriptionChecker = new SubscriptionChecker()
            //    {
            //        CheckedOn = DateTime.Now,
            //        Id = Guid.NewGuid(),
            //        ValidateToken = validationToken
            //    };
            //    databaseContext.SubscriptionChecker.Add(SubscriptionChecker);
            //    databaseContext.SaveChanges();
            //    return Content(validationToken);
            //}
            return null;
        }
        private async Task GetChangedMessagesAsync(List<value> notifications)
        {
            foreach (var notification in notifications)
            {



                if (notification.resourceData.oDataType == "#microsoft.graph.callrecord")
                {

                    var Accesstoken = await AuthenticateOutboundRequestAsync(notification.tenantId.ToString(), KeyVaultOptions.Value.ClientId, KeyVaultOptions.Value.ClientSecret);
                    var GetToken = JsonConvert.DeserializeObject<Token>(Accesstoken);
                    var GetInformation = await GetCallInformation(GetToken.access_token, notification.resourceData.oDataId);
                    var ConvertData = JsonConvert.DeserializeObject<Records>(GetInformation);
                    var Sessions = ConvertData.Sessions.FirstOrDefault();
                    try
                    {
                        if (databaseContext.recordsTables.Where(x => x.RecoredId == ConvertData.Id).FirstOrDefault() == null)
                        {
                            if (ConvertData.Type != "groupCall")
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
                                    else if (Sessions.Caller.UserAgent.Platform == "unknown")
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
                                    }
                                    else
                                    {
                                        var GetCaldulcatedData = CalculateCall(Sessions?.Caller?.Identity?.Phone?.Id, TotalTime);
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
                                        if (Sessions.Callee.Identity.Phone != null)
                                        {
                                            var GetCaldulcatedData = CalculateCall(Sessions?.Callee?.Identity?.Phone?.Id, TotalTime);
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
                                        else
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
                                    else
                                    {
                                        if (Sessions.Caller.Identity.Phone != null)
                                        {
                                            var GetCaldulcatedData = CalculateCall(Sessions?.Caller?.Identity?.Phone?.Id, TotalTime);
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
                                        else if (Sessions.Callee.Identity.Phone != null)
                                        {
                                            var GetCaldulcatedData = CalculateCall(Sessions?.Callee?.Identity?.Phone?.Id, TotalTime);
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
                                        else
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
                                databaseContext.SaveChanges();
                            }
                            else {
                                var TotalTime = ConvertData.EndDateTime - ConvertData.StartDateTime;

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
                    catch (Exception ex)
                    {

                        logger.LogError($"ParsingNotification: { ex.Message }" + "------ Call ID:" + notification.resourceData.oDataId);

                    }

                }


            }


        }
        public async Task<string> AuthenticateOutboundRequestAsync(string TenatID, string ClientID, string ClientSecret)
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
                IRestResponse response = client.Execute(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                logger.LogError($"ParsingNotification: { ex.Message }");
                return null;
            }

            // request.Headers.Authorization = new AuthenticationHeaderValue(schema, result.AccessToken);
        }
        public CalculatedData CalculateCall(string Phone, TimeSpan TotalTime)
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
                logger.LogError($"ParsingNotification: { ex.Message }");
                return null;
            }

            // request.Headers.Authorization = new AuthenticationHeaderValue(schema, result.AccessToken);
        }

        public async Task<string> GetCallInformation(string token, string resource)
        {
            try
            {
                var client = new RestClient("https://graph.microsoft.com/v1.0/" + resource + "?$expand=sessions($expand=segments)")
                {
                    Timeout = -1
                };
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("text/plain", "", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response.Content;
            }
            catch (Exception ex)
            {
                logger.LogError($"ParsingNotification: { ex.Message }");
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
