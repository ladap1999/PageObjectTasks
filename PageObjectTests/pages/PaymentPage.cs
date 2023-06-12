using OpenQA.Selenium;
using PageObjectTests.services;

namespace PageObjectTests.pages;

public class PaymentPage : BasePage
{
    private readonly By _placeOrderButtonLocator = By.CssSelector(".action.primary.checkout");
    private readonly By _continueButtonLocator = By.CssSelector(".action.primary.continue");
    private readonly By _orderNumberLinkLocator = By.CssSelector(".order-number");

    public PaymentPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
    }

    public PaymentPage ClickPlaceOrderButton()
    {
        var placeOrderButton = waitService.waitForVisability(_placeOrderButtonLocator);
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
        jsExecutor.ExecuteScript("arguments[0].click();", placeOrderButton);
        return this;
    }

    public MainPage ClickContinueButton()
    {
        orderNumber = driver.FindElement(_orderNumberLinkLocator).Text;
        waitService.waitForVisability(_continueButtonLocator).Click();
        return new MainPage(driver, waitService);
    }
}