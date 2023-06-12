using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObjectTests.services;

namespace PageObjectTests.pages.productsPages;

public class WatchesPage : BasePage
{
    private readonly By _dushWatchItemLocator = By.XPath("//*[contains(text(),'Dash Digital Watch')]");
    private readonly By _addToCartButtonLocator =
        By.XPath(
            "//*[contains(text(),'Dash Digital Watch')]/parent::strong/following-sibling::div[@class = 'product-item-inner']/descendant::button");
    private readonly By _cartNumberLinkLocator = By.XPath("//*[@class='counter-number'][text() = '1']");
    private readonly By _proceedToCheckoutButtonLocator = By.Id("top-cart-btn-checkout");
    private readonly By _addedLocator = By.XPath("//div[contains(text(), 'You added Dash Digital Watch')]");
    private readonly Actions _action;
    
    public WatchesPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
        _action = new Actions(driver);
    }

    public WatchesPage AddItemToTheCart()
    {
        _action.MoveToElement(driver.FindElement(_dushWatchItemLocator));
        _action.Perform();
        driver.FindElement(_addToCartButtonLocator).Click();
        return this;
    }

    public CheckoutPage ProceedToCheckout()
    {
        waitService.waitForVisability(_addedLocator);
        _action.MoveToElement(waitService.waitForExists(_cartNumberLinkLocator)).Click().Build().Perform();
        _action.MoveToElement(waitService.waitForVisability(_proceedToCheckoutButtonLocator)).Click().Build().Perform();
        return new CheckoutPage(driver, waitService);
    }
}