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

            public static async System.Threading.Tasks.Task CreateSubscriptionAsync()
            {

                try
                {
                    var Accesstoken = AuthenticateOutboundRequest();
                    var GetToken = JsonConvert.DeserializeObject<Token>(Accesstoken);

                    string clientState = Guid.NewGuid().ToString();
                    var graphClient = new GraphServiceClient($"https://graph.microsoft.com/v1.0", new DelegateAuthenticationProvider(
                        (requestMessage) =>
                        {
                        // Append the access token to the request.
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                            JwtBearerDefaults.AuthenticationScheme, GetToken.access_token);
                            return Task.CompletedTask;
                        }));

                    var newSubscription = await graphClient.Subscriptions.Request().AddAsync(new Subscription
                    {
                        Resource = "communications/callRecords",
                        ChangeType = "created,updated",
                        NotificationUrl = "https://billingsystem.paisgroup.com/API/Notify/Listen",
                        ClientState = clientState,
                        LatestSupportedTlsVersion = "v1_2",
                        ExpirationDateTime = DateTime.UtcNow + new TimeSpan(0, 0, 1445, 0),     // 4230 minutes is the current max lifetime, shorter duration useful for testing
                    });
                }
                catch (Exception e)
                {
                    var s = e;

                }


            }
            public static string AuthenticateOutboundRequest()
            {
                try
                {
                    var client = new RestClient("https://login.microsoftonline.com/a5ec227e-1161-487d-8e4b-168353d1a844/oauth2/v2.0/token");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    request.AddHeader("Cookie", "x-ms-gateway-slice=estsfd; stsservicecookie=estsfd; fpc=AoM0xEFcWYJNjc0RXZQvPM2m5zo5AQAAAIv3ZtYOAAAA");
                    request.AddParameter("grant_type", "client_credentials");
                    request.AddParameter("client_id", "961c04f4-9003-4613-8b85-cabd4989e8e5");
                    request.AddParameter("client_secret", "y50si6HmdO~MMTYhg-r~r1W2~1vHYS-hgx");
                    request.AddParameter("scope", "https://graph.microsoft.com/.default");
                    IRestResponse response = client.Execute(request);

                    return response.Content;
                }
                catch (Exception e)
                {
                    return null;
                }

                // request.Headers.Authorization = new AuthenticationHeaderValue(schema, result.AccessToken);
            }
        }
    
}
