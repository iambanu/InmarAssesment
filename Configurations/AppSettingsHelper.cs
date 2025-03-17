using Microsoft.Extensions.Configuration;

namespace SpecFlowProjectFramework.Configurations
{
    public class AppSettingsHelper
    {
        public static string GetAppSettingsValue(string key)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true);
            var config = builder.Build();
            var value = config[$"{key}"];
            return value;
        }
    }
}



