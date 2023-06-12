using OpenQA.Selenium;
using PageObjectTests.services;

namespace PageObjectTests.pages.productDetailPages;

public class BagItemPage : BasePage
{
    private readonly By _addToCartDrivenBagButtonLocator = By.Id("product-addtocart-button");
    
    private readonly By _cartNumberLinkLocator = By.XPath("//*[@class='counter-number']");
    private readonly By _addedLocator = By.XPath("//div[contains(text(), 'You added Driven Backpack')]");
    
    public BagItemPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
    }

    public BagItemPage AddBagsToTheCart()
    {
        waitService.waitForVisability(_addToCartDrivenBagButtonLocator).Click();
        return this;
    }

    public string GetTheCartNumber()
    {
        waitService.waitForVisability(_addedLocator);
        return waitService.waitForExists(_cartNumberLinkLocator).Text;
    }
}