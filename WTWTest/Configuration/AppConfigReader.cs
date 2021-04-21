using Microsoft.Extensions.Configuration;
using WTWTest.Interfaces;

namespace WTWTest.Configuration
{
    public class AppConfigReader : IConfig
    {
        public IConfigurationRoot GetConfiguration()
        {
            var config = new ConfigurationBuilder().AddJsonFile(@"ConfigFiles\AppConfig.json", optional: false, reloadOnChange: true).Build();

            return config;
        }
    }
}
