namespace WTWTest.Configuration
{
    public static class WebsiteConfigSection
    {
        private static readonly AppConfigReader Config = new AppConfigReader();

        public static string GetWebsiteUrl()
        {
            return Config.GetConfiguration().GetSection("Website")["Url"];
        }
    }
}
