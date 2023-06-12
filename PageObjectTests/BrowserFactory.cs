using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectTests;

public class BrowserFactory
{
    private IWebDriver _driver;

    public BrowserFactory()
    {
        switch (ConfigurationManager.AppSetting["browser"])
        {
            case "chrome":
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("headless");
                chromeOptions.AddArguments("--start-maximized");
                _driver = new ChromeDriver();
                break;
        }
    }
    
    public IWebDriver GetDriver() {
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        return _driver;
    }
}