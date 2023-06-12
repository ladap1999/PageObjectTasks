using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectTests.pages;
using PageObjectTests.services;

namespace PageObjectTests.tests;

public class BaseTest
{
    protected IWebDriver _driver;
    protected MainPage mainPage;
    protected WaitService _waitService;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _driver = new BrowserFactory().GetDriver();
        _waitService = new WaitService(_driver);
        _driver.Navigate().GoToUrl(ConfigurationManager.AppSetting["baseURL"]);
        mainPage = new MainPage(_driver, _waitService);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
    }
    
    
    [TearDown]
    public void TearDown()
    {   var specialTearDownTests = TestContext.CurrentContext.Test.Properties
            .Get("WithoutLogOut");
        if (Convert.ToBoolean(specialTearDownTests))
        {
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSetting["baseURL"]);
            ClearTestData(_driver, _waitService);
            mainPage.LogOut();
        }
    }

    public void ClearTestData(IWebDriver driver, WaitService waitService)
    {
        _driver.Navigate().GoToUrl(ConfigurationManager.AppSetting["baseURL"]);
        mainPage = new MainPage(driver, waitService);
        mainPage.DeleteCartData();
    }
}