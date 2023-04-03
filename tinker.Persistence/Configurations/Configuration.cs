using Microsoft.Extensions.Configuration;

namespace tinker.Persistence.Configurations
{
    static class Configuration
    {
        static private string getBasePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/tinker.API");
        }
        public static string InMemoryConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(getBasePath());
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("InMemoryDatabase");
            }
        }
    }
}
