namespace PC_appium_C_.Config;

public sealed class AndroidPCloudySettings
{
    public string Username { get; init; } = PCloudyEnvironment.Get("PCLOUDY_USERNAME", "Your-Username");
    public string ApiKey { get; init; } = PCloudyEnvironment.Get("PCLOUDY_API_KEY", "YOUR-API-KEY");
    public string AppiumEndpoint { get; init; } = PCloudyEnvironment.Get("PCLOUDY_CLOUD_URL", "https://device.pcloudy.com/appiumcloud/wd/hub");
    public string AppName { get; init; } = PCloudyEnvironment.Get("PCLOUDY_APP_PATH", "pCloudyAppiumDemo.apk");
    public string Manufacturer { get; init; } = PCloudyEnvironment.Get("PCLOUDY_DEVICE_MANUFACTURER", "ONEPLUS");
    public string PlatformVersion { get; init; } = PCloudyEnvironment.Get("PCLOUDY_PLATFORM_VERSION", "13.0.0");
    public string Platform { get; init; } = PCloudyEnvironment.Get("PCLOUDY_PLATFORM_NAME", "Android");
}
