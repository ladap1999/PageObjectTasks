using OpenQA.Selenium;
using PageObjectTests.services;

namespace PageObjectTests.pages;

public class LoginPage : BasePage
{
    private readonly By _emailInputLocator = By.Id("email");
    private readonly By _passwordInputLocator = By.Id("pass");
    private readonly By _signInButtonLocator = By.Id("send2");
    
    public LoginPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
    }

    public LoginPage InputCredentials(string email, string password)
    {
        driver.FindElement(_emailInputLocator).SendKeys(email);
        driver.FindElement(_passwordInputLocator).SendKeys(password);
        return this;
    }
    
    public MainPage ClickSingInButton()
    {
       driver.FindElement(_signInButtonLocator).Click();
       return new MainPage(driver, waitService);
    }
    
}