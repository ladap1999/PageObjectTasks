using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace PageObjectTests.services;
using OpenQA.Selenium.Support.UI;

public class WaitService
{
    private IWebDriver _driver;
    private WebDriverWait wait;

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
        this.wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
    }

    public IWebElement waitForExists(By locator) {
        return wait.Until(ExpectedConditions.ElementExists(locator));
    }
    
    public IWebElement waitForVisability(By locator) {
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }
    
    public ICollection<IWebElement> waitForVisibilityOfAllElements(By locator) {
        return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
    }
}
