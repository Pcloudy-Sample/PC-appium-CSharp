using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using PC_appium_C_.Config;
using PC_appium_C_.Src;
using System.IO;

namespace PC_appium_C_.Tests;

[TestFixture]
public class AndroidAppRunner
{
    private AndroidDriver? _driver;

    [SetUp]
    public void SetUp()
    {
        var settings = new AndroidPCloudySettings();
        _driver = PCloudyDriverFactory.CreateAndroidDriver(settings);
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }

    [Test]
    public void RunAppFlow()
    {
        Assert.That(_driver, Is.Not.Null);

        var driver = _driver!;
        var screenshotsDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "screenshots");
        Directory.CreateDirectory(screenshotsDir);

        driver.FindElement(By.XPath("//android.widget.Button[@resource-id='com.pcloudy.appiumdemo:id/accept']")).Click();
        CaptureScreenshot(driver, screenshotsDir, "01-accept");
        driver.FindElement(By.XPath("//android.widget.Button[@resource-id='com.pcloudy.appiumdemo:id/flightButton']")).Click();
        CaptureScreenshot(driver, screenshotsDir, "02-flight-button");

        driver.FindElement(By.XPath("//android.widget.Spinner[@resource-id='com.pcloudy.appiumdemo:id/spinnerfrom']")).Click();
        driver.FindElement(By.XPath("//android.widget.CheckedTextView[@resource-id='android:id/text1' and @text='Bangalore, India (BLR)']")).Click();
        CaptureScreenshot(driver, screenshotsDir, "03-from-selected");

        driver.FindElement(By.XPath("//android.widget.Spinner[@resource-id='com.pcloudy.appiumdemo:id/spinnerto']")).Click();
        driver.FindElement(By.XPath("//android.widget.CheckedTextView[@resource-id='android:id/text1' and @text='Pune, India (PNQ)']")).Click();
        CaptureScreenshot(driver, screenshotsDir, "04-to-selected");

        driver.FindElement(By.XPath("//android.widget.RadioButton[@resource-id='com.pcloudy.appiumdemo:id/singleTrip']")).Click();
        driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.pcloudy.appiumdemo:id/txtdepart']")).Click();
        driver.FindElement(By.XPath("//android.widget.Button[@resource-id='android:id/button1' and @text='OK']")).Click();
        CaptureScreenshot(driver, screenshotsDir, "05-date-selected");
        driver.FindElement(By.XPath("//android.widget.Button[@resource-id='com.pcloudy.appiumdemo:id/searchFlights']")).Click();
        CaptureScreenshot(driver, screenshotsDir, "06-search-flights");
    }

    private static void CaptureScreenshot(AndroidDriver driver, string screenshotsDir, string name)
    {
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        var path = Path.Combine(screenshotsDir, $"{name}.png");
        screenshot.SaveAsFile(path);
    }
}
