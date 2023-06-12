using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObjectTests.pages.productDetailPages;
using PageObjectTests.services;

namespace PageObjectTests.pages.productsPages;

public class BagsPage : BasePage
{
    private Actions _action;
    private readonly By _messengerBagsItemLocator = By.XPath("//*[contains(text(),'Push It')]");
    private readonly By _overnightBagsItemLocator = By.XPath("//*[contains(text(),'Overnight D')]");
    private readonly By _drivenBagsItemLocator = By.XPath("//*[contains(text(),'Driven')]");
    private readonly By _addToCartMessengerBagButtonLocator =
        By.XPath(
            "//*[contains(text(),'Push It')]/parent::strong/following-sibling::div[@class = 'product-item-inner']/descendant::button");
    private readonly By _addToCartOvernightBagButtonLocator =
        By.XPath(
            "//*[contains(text(),'Overnight D')]/parent::strong/following-sibling::div[@class = 'product-item-inner']/descendant::button");
   
    public BagsPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
        _action = new Actions(driver);
    }
    
    public BagItemPage AddItemsToTheCart()
    {
        _action.MoveToElement(driver.FindElement(_messengerBagsItemLocator));
        _action.Perform();
        driver.FindElement(_addToCartMessengerBagButtonLocator).Click();
        _action.MoveToElement(driver.FindElement(_overnightBagsItemLocator));
        _action.Perform();
        driver.FindElement(_addToCartOvernightBagButtonLocator).Click();
        _action.MoveToElement(driver.FindElement(_drivenBagsItemLocator)).Click().Build().Perform();
        return new BagItemPage(driver,waitService);
    }
}