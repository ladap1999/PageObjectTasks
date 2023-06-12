using OpenQA.Selenium;
using PageObjectTests.services;

namespace PageObjectTests.pages;

public class CheckoutPage : BasePage
{
    private readonly By _streetInputLocator = By.XPath("//*[@name = 'street[0]']");
    private readonly By _cityInputLocator = By.XPath("//*[@name = 'city']");
    private readonly By _postcodeInputLocator = By.XPath("//*[@name = 'postcode']");
    private readonly By _regionInputLocator = By.XPath("//*[@name = 'region_id']");
    private readonly By _countryInputLocator = By.XPath("//option[@data-title = 'Alaska']");
    private readonly By _telephoneInputLocator = By.XPath("//*[@name = 'telephone']");
    private readonly By _shippingRadioButtonLocator = By.XPath("//*[@name = 'ko_unique_3']");
    private readonly By _continueButtonLocator = By.CssSelector("button.action.continue");
    private readonly By _newAddressButtonLocator = By.XPath("//button[@class='action action-show-popup']");
    private readonly By _shipHereButtonLocator = By.XPath("//*[contains(@class,'save-address')]/child::*");

    public CheckoutPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
    }

    public PaymentPage AddOrderData(string street, string city, string postcode, int telephone)
    {
        var newAddressButton = waitService.waitForVisability(_newAddressButtonLocator);
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
        jsExecutor.ExecuteScript("arguments[0].click();", newAddressButton);
  
        waitService.waitForVisability(_streetInputLocator).SendKeys(street);
        driver.FindElement(_cityInputLocator).SendKeys(city);
        driver.FindElement(_telephoneInputLocator).SendKeys(Convert.ToString(telephone));
        driver.FindElement(_postcodeInputLocator).SendKeys(postcode);
        driver.FindElement(_regionInputLocator).Click();
        driver.FindElement(_countryInputLocator).Click();

        waitService.waitForVisability(_shipHereButtonLocator).Click();
        waitService.waitForVisability(_shippingRadioButtonLocator).Click();
        waitService.waitForVisability(_continueButtonLocator).Click();
        return new PaymentPage(driver, waitService);
    }
}