using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObjectTests.pages.productCategoryPages;
using PageObjectTests.pages.productsPages;
using PageObjectTests.services;

namespace PageObjectTests.pages;

public class MainPage : BasePage
{
    private Actions _action;
    private readonly By _signInButtonLocator = By.ClassName("authorization-link");

    private readonly By _createAccountLinkLocator =
        By.XPath("//*[@class ='header content']/preceding::a[text() = 'Create an Account']");

    private readonly By _menuButtonLocator =
        By.XPath("//*[@id = 'store.menu']/preceding::button[@class = 'action switch']");

    private readonly By _myAccountLinkLocator =
        By.XPath("//*[@id = 'store.menu']/preceding::a[text() = 'My Account']");

    private readonly By _signOutLinkLocator =
        By.XPath("//*[@aria-hidden = 'false']/descendant::*[@class  = 'authorization-link']");
    private readonly By _gearLinkLocator = By.Id("ui-id-6");
    private readonly By _watchesLinkLocator = By.XPath("//*[text() ='Watches']");
    private readonly By _deleteLinkLocator = By.XPath("//*[@class = 'action action-delete']");
    private readonly By _viewButtonLocator = By.CssSelector(".action.viewcart");
    private readonly By _cartNumberLinkLocator = By.XPath("//*[@class = 'counter-number']");

    public MainPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
        _action = new Actions(driver);
    }

    public LoginPage ClickSignInButton()
    {
        driver.FindElement(_signInButtonLocator).Click();

        return new LoginPage(driver, waitService);
    }

    public CreateAccountPage FollowToCreationOfAccount()
    {
        waitService.waitForVisability(_createAccountLinkLocator).Click();

        return new CreateAccountPage(driver, waitService);
    }

    public AccountPage GoToAccount()
    {
        waitService.waitForVisability(_menuButtonLocator).Click();
        waitService.waitForVisability(_myAccountLinkLocator).Click();
        return new AccountPage(driver, waitService);
    }

    public void LogOut()
    {
        waitService.waitForVisability(_menuButtonLocator).Click();
        waitService.waitForVisability(_signOutLinkLocator).Click();
    }

    public WatchesPage MoveToGearAndClickWatchesLink()
    {
        _action.MoveToElement(driver.FindElement(_gearLinkLocator));
        _action.Perform();
        waitService.waitForExists(_watchesLinkLocator).Click();
        return new WatchesPage(driver, waitService);
    }

    public GearPage ClickOnGear()
    {
        waitService.waitForVisability(_gearLinkLocator).Click();
        return new GearPage(driver, waitService);
    }

    public void DeleteCartData()
    {
        try
        {
            waitService.waitForVisability(_cartNumberLinkLocator).Click();
        }
        catch (Exception e)
        {
            return;
        }

        driver.FindElement(_viewButtonLocator).Click();
        var amountOfBasket = waitService.waitForVisibilityOfAllElements(_deleteLinkLocator);

        for (int i = 0; i < amountOfBasket.Count; i++)
        {
            waitService.waitForVisability(_deleteLinkLocator).Click();
        }
    }
}