using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using PC_appium_C_.Config;
using System.Text.Json;
using System.Collections.Generic;

namespace PC_appium_C_.Src;

public static class PCloudyDriverFactory
{
    public static AndroidDriver CreateAndroidDriver(AndroidPCloudySettings settings)
    {
        var payload = new
        {
            platformName = "Android",
            pCloudy_Username = settings.Username,
            pCloudy_ApiKey = settings.ApiKey,
            pCloudy_DeviceManufacturer = settings.Manufacturer,
            pCloudy_DevicePlatformVersion = settings.PlatformVersion,
            pCloudy_WildNet = false,
            pCloudy_EnableVideo = true,
            pCloudy_EnablePerformanceData = false,
            pCloudy_EnableDeviceLogs = false,
            appiumVersion = "3.1.1",
            pCloudy_ApplicationName = settings.AppName,
            appPackage = "com.pcloudy.appiumdemo",
            appActivity = "com.ba.mobile.LaunchActivity"
        };

        Console.WriteLine("Capability payload:");
        Console.WriteLine(JsonSerializer.Serialize(payload));

        var options = new AppiumOptions
        {
            PlatformName = settings.Platform,
            AutomationName = "uiautomator2",
            PlatformVersion = settings.PlatformVersion
        };

        options.AddAdditionalAppiumOption("appium:newCommandTimeout", 600);
        options.AddAdditionalAppiumOption("appium:launchTimeout", 90000);
        options.AddAdditionalAppiumOption("appium:platformName", settings.Platform);
        options.AddAdditionalAppiumOption("appium:appPackage", "com.pcloudy.appiumdemo");
        options.AddAdditionalAppiumOption("appium:appActivity", "com.ba.mobile.LaunchActivity");
        options.AddAdditionalAppiumOption("appium:pCloudy_ApplicationName", settings.AppName);

        var pcloudyOptions = new Dictionary<string, object>
        {
            ["pCloudy_Username"] = settings.Username,
            ["pCloudy_ApiKey"] = settings.ApiKey,
            ["pCloudy_DeviceManufacturer"] = settings.Manufacturer,
            ["pCloudy_DevicePlatformVersion"] = settings.PlatformVersion,
            ["pCloudy_WildNet"] = false,
            ["pCloudy_EnableVideo"] = true,
            ["pCloudy_EnablePerformanceData"] = false,
            ["pCloudy_EnableDeviceLogs"] = false,
            ["appiumVersion"] = "3.1.1"
        };

        options.AddAdditionalAppiumOption("pcloudy:options", pcloudyOptions);

        return new AndroidDriver(new Uri(settings.AppiumEndpoint), options, TimeSpan.FromMinutes(5));
    }
}
