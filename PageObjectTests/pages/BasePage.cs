using OpenQA.Selenium;
using PageObjectTests.services;

namespace PageObjectTests.pages;

public class BasePage
{
    protected IWebDriver driver;
    protected WaitService waitService;
    public static string orderNumber;

    public BasePage(IWebDriver driver, WaitService waitService)
    {
        this.driver = driver;
        this.waitService = waitService;
    }
}