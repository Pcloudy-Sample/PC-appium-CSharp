using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using PC_appium_C_.Config;
using PC_appium_C_.Src;
using System.IO;

namespace PC_appium_C_.Tests;

[TestFixture]
public class IOSAppRunner
{
    private IOSDriver? _driver;

    [SetUp]
    public void SetUp()
    {
        var settings = new IosPCloudySettings();
        _driver = PCloudyIosDriverFactory.CreateIosDriver(settings);
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }

    [Test]
    public void RunIosFlow()
    {
        Assert.That(_driver, Is.Not.Null);

        var driver = _driver!;
        var screenshotsDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "screenshots-ios");
        Directory.CreateDirectory(screenshotsDir);

        driver.FindElement(By.XPath("//XCUIElementTypeApplication[1]/XCUIElementTypeWindow[1]/XCUIElementTypeOther[1]/XCUIElementTypeTextField[1]")).SendKeys("test@testname.com");
        CaptureScreenshot(driver, screenshotsDir, "01-username");

        driver.FindElement(By.XPath("//XCUIElementTypeApplication[1]/XCUIElementTypeWindow[1]/XCUIElementTypeOther[1]/XCUIElementTypeSecureTextField[1]")).SendKeys("testmunk");
        CaptureScreenshot(driver, screenshotsDir, "02-password");

        driver.FindElement(By.XPath("//XCUIElementTypeApplication[1]/XCUIElementTypeWindow[1]/XCUIElementTypeOther[1]/XCUIElementTypeButton[1]")).Click();
        CaptureScreenshot(driver, screenshotsDir, "03-login");

        driver.FindElement(By.XPath("//XCUIElementTypeButton[@name='Skip']")).Click();
        driver.FindElement(By.XPath("//*[contains(@name,'SHOW ALERT VIEW')]")).Click();
        CaptureScreenshot(driver, screenshotsDir, "04-alert-view");
    }

    private static void CaptureScreenshot(IOSDriver driver, string screenshotsDir, string name)
    {
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        var path = Path.Combine(screenshotsDir, $"{name}.png");
        screenshot.SaveAsFile(path);
    }
}
