namespace PC_appium_C_.Config;

public interface IIosPCloudySettings
{
    string Username { get; }
    string ApiKey { get; }
    string AppiumEndpoint { get; }
    string AppName { get; }
    string Manufacturer { get; }
    string PlatformVersion { get; }
    string Platform { get; }
}
