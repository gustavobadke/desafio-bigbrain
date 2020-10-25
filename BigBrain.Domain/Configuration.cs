using Microsoft.Extensions.Configuration;
using System.Linq;

namespace BigBrain.Domain
{
    public class Configuration
    {
        public static void SetVariables(IConfiguration config)
        {
            var credencialItems = config.GetSection("MicrosoftCredentials").GetChildren();

            MicrosoftCredentials = new MicrosoftCredentialsConfiguration
            {
                AppId = credencialItems.First(m => m.Key == "AppId").Value,
                TenantId = credencialItems.First(m => m.Key == "TenantId").Value,
                Secret = credencialItems.First(m => m.Key == "Secret").Value
            };
        }

        public static MicrosoftCredentialsConfiguration MicrosoftCredentials { get; set; }
    }

    public class MicrosoftCredentialsConfiguration
    {
        public string AppId { get; set; }
        public string TenantId { get; set; }
        public string Secret { get; set; }
    }
}