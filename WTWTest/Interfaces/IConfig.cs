using Microsoft.Extensions.Configuration;

namespace WTWTest.Interfaces
{
    public interface IConfig
    {
        IConfigurationRoot GetConfiguration();
    }
}
