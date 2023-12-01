using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.Json;

namespace service
{
    internal class Configuration
    {
        internal static string GetAppsettings(string appKey)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");

            IConfiguration configuration = configurationBuilder.Build();
            string keyvalue = string.Empty;

            if (configuration[appKey] != null)
            {
                keyvalue = configuration[appKey];
            }
            return keyvalue;
        }
    }
}
