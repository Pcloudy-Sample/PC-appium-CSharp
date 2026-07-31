using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using PC_appium_C_.Config;
using System.Collections.Generic;
using System.Text.Json;

namespace PC_appium_C_.Src;

public static class PCloudyIosDriverFactory
{
    public static IOSDriver CreateIosDriver(IIosPCloudySettings settings)
    {
        var payload = new
        {
            platformName = "iOS",
            pCloudy_Username = settings.Username,
            pCloudy_ApiKey = settings.ApiKey,
            pCloudy_DeviceManufacturer = settings.Manufacturer,
            pCloudy_DevicePlatformVersion = settings.PlatformVersion,
            pCloudy_WildNet = false,
            pCloudy_EnableVideo = false,
            pCloudy_EnablePerformanceData = false,
            pCloudy_EnableDeviceLogs = false,
            appiumVersion = "3.1.1",
            pCloudy_ApplicationName = settings.AppName
        };

        Console.WriteLine("iOS Capability payload:");
        Console.WriteLine(JsonSerializer.Serialize(payload));

        var options = new AppiumOptions
        {
            PlatformName = settings.Platform,
            AutomationName = "XCUITest",
            PlatformVersion = settings.PlatformVersion
        };

        options.AddAdditionalAppiumOption("appium:newCommandTimeout", 600);
        options.AddAdditionalAppiumOption("appium:launchTimeout", 90000);
        options.AddAdditionalAppiumOption("appium:platformName", settings.Platform);
        options.AddAdditionalAppiumOption("appium:acceptAlerts", true);
        options.AddAdditionalAppiumOption("appium:pCloudy_ApplicationName", settings.AppName);
        options.AddAdditionalAppiumOption("appium:bundleId", "com.pcloudy.TestmunkDemo");

        var pcloudyOptions = new Dictionary<string, object>
        {
            ["pCloudy_Username"] = settings.Username,
            ["pCloudy_ApiKey"] = settings.ApiKey,
            ["pCloudy_DeviceManufacturer"] = settings.Manufacturer,
            ["pCloudy_DevicePlatformVersion"] = settings.PlatformVersion,
            ["pCloudy_WildNet"] = false,
            ["pCloudy_EnableVideo"] = false,
            ["pCloudy_EnablePerformanceData"] = false,
            ["pCloudy_EnableDeviceLogs"] = false,
            ["appiumVersion"] = "3.1.1"
        };

        options.AddAdditionalAppiumOption("pcloudy:options", pcloudyOptions);

        return new IOSDriver(new Uri(settings.AppiumEndpoint), options, TimeSpan.FromMinutes(5));
    }
}
