namespace PC_appium_C_.Config;

public sealed class IosPCloudySettings : IIosPCloudySettings
{
    public string Username { get; init; } = PCloudyEnvironment.Get("PCLOUDY_USERNAME", "Your-Usename");
    public string ApiKey { get; init; } = PCloudyEnvironment.Get("PCLOUDY_API_KEY", "YOUR-API-KEY");
    public string AppiumEndpoint { get; init; } = PCloudyEnvironment.Get("PCLOUDY_CLOUD_URL", "https://device.pcloudy.com/appiumcloud/wd/hub");
    public string AppName { get; init; } = PCloudyEnvironment.Get("PCLOUDY_APP_PATH", "pCloudy_Appium_Demo.ipa");
    public string Manufacturer { get; init; } = PCloudyEnvironment.Get("PCLOUDY_DEVICE_MANUFACTURER", "Apple");
    public string PlatformVersion { get; init; } = PCloudyEnvironment.Get("PCLOUDY_PLATFORM_VERSION", "16.1.1");
    public string Platform { get; init; } = PCloudyEnvironment.Get("PCLOUDY_PLATFORM_NAME", "iOS");
}
