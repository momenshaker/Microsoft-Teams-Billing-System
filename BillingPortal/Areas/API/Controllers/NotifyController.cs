
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
    
    }

}
