using OpenQA.Selenium;
using PageObjectTests.services;

namespace PageObjectTests.pages;

public class CreateAccountPage : BasePage
{
    private readonly By _firstNameItemLocator = By.Id("firstname");
    private readonly By _lastNameItemLocator = By.Id("lastname");
    private readonly By _passwordItemLocator = By.Id("password");
    private readonly By _passwordConfirmationItemLocator = By.Id("password-confirmation");
    private readonly By _createAccountButtonLocator = By.CssSelector(".action.submit.primary");
    private readonly By _errorMessageLocator = By.Id("email_address-error");
   
    public CreateAccountPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
    }

    public string CreateAccount(string name, string secondName, string password)
    {
        driver.FindElement(_firstNameItemLocator).SendKeys(name);
        driver.FindElement(_lastNameItemLocator).SendKeys(secondName);
        driver.FindElement(_passwordItemLocator).SendKeys(password);
        driver.FindElement(_passwordConfirmationItemLocator).SendKeys(password);
        driver.FindElement(_createAccountButtonLocator).Click();
        Thread.Sleep(TimeSpan.FromSeconds(10));
        return waitService.waitForVisability(_errorMessageLocator).Text;
    }
}