using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinker.Persistence.Configurations
{
    // DEPRECATED CLASS, NOT IN USE
    static class ConfigManager
    {
        static private string getBasePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "../../tinker.API");
        }
        public static string InMemoryConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(getBasePath());
                configurationManager.AddJsonFile("appsettings.json");

                return ""; //configurationManager.GetConnectionString();
            }
        }
    }
}
