using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace WTWTest.TestExecutionHelper
{
    public class ChromeDriverVersionHelper
    {
        public static string GetChromeBrowserVersion()
        {
            var path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null);
            return new Version(FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion).ToString(1);
        }

        public static string GetDriverVersion()
        {
            string chromeVersion = GetChromeBrowserVersion();
            string endpoint = "https://chromedriver.storage.googleapis.com/LATEST_RELEASE_" + chromeVersion;
            ApiHelper.RestApiHelper.SetUrl(endpoint);
            ApiHelper.RestApiHelper.CreateRequest();
            string driverVersion = ApiHelper.RestApiHelper.GetResponse().Content;
            return driverVersion;
        }
    }
}
