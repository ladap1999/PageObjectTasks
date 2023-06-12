using OpenQA.Selenium;
using PageObjectTests.models;
using PageObjectTests.services;

namespace PageObjectTests.pages;

public class AccountPage : BasePage
{
    private readonly By _myOderLinkLocator = By.XPath("//*[text() = 'My Orders']");
    private readonly By _productNameItemLocator = By.CssSelector(".product.name.product-item-name");
    private readonly By _subtitleItemLocator = By.XPath("//*[@class ='amount'][@data-th = 'Subtotal']");

    private readonly By _shippingItemLocator =
        By.XPath("//*[@class ='amount'][@data-th = 'Shipping & Handling']");

    private readonly By _totalItemLocator = By.XPath("//*[@class ='amount'][@data-th = 'Grand Total']");


    public AccountPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
    }

    public By GetViewOrderLocator(string id)
    {
        return By.XPath($"//*[@class = 'col id'][text()='{id}']/following-sibling::td/a[@class = 'action view']");
    }

    public OrderModel GoToOder()
    {
        waitService.waitForVisability(_myOderLinkLocator).Click();
        waitService.waitForVisability(GetViewOrderLocator(orderNumber)).Click();
        return new OrderModel(
            driver.FindElement(_productNameItemLocator).Text,
            driver.FindElement(_subtitleItemLocator).Text,
            driver.FindElement(_shippingItemLocator).Text,
            driver.FindElement(_totalItemLocator).Text
        );
    }
}