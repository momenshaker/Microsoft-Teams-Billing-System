using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BillingWorker.Helpers
{
    public static class GraphServiceClientFactory
    {
        public static async Task<Microsoft.Graph.GraphServiceClient> GetAuthenticatedGraphClient(string baseUrl, Func<Task<string>> acquireAccessToken)
        {
            // Fetch the access token
            string accessToken = await acquireAccessToken.Invoke();

            return new GraphServiceClient($"{baseUrl}/v1.0", new DelegateAuthenticationProvider(
                    (requestMessage) =>
                    {
                        // Append the access token to the request.
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                        JwtBearerDefaults.AuthenticationScheme, accessToken);
                        return Task.CompletedTask;
                    }));
        }
    }
}
