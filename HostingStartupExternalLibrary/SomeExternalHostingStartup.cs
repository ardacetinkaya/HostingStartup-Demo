using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;

[assembly: HostingStartup(typeof(HostingStartupExternalLibrary.SomeExternalHostingStartup))]
namespace HostingStartupExternalLibrary
{
    public class SomeExternalHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "SomeSpecificCustomer");
            string boredAPIResult = client.GetStringAsync("https://www.boredapi.com/api/activity").Result;
            var activity = System.Text.Json.JsonDocument.Parse(boredAPIResult);

            builder.ConfigureAppConfiguration((host, config) =>
            {
                var externalSettings = new Dictionary<string, string>
                {
                    {"EXTERNAL_STARTUP_ACTIVITY", activity.RootElement.GetProperty("activity").GetString()},
                    {"EXTERNAL_STARTUP_TYPE", activity.RootElement.GetProperty("type").GetString()},
                    {"EXTERNAL_STARTUP_KEY", activity.RootElement.GetProperty("key").GetString()}
                };

                config.AddInMemoryCollection(externalSettings);


            });
        }
    }
}
