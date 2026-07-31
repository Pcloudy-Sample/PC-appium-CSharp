namespace PC_appium_C_.Config;

public static class PCloudyEnvironment
{
    internal static string Get(string name, string fallback)
    {
        var value = Environment.GetEnvironmentVariable(name);
        return string.IsNullOrWhiteSpace(value) ? fallback : value;
    }
}
