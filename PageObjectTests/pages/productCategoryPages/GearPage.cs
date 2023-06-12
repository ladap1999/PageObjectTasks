using OpenQA.Selenium;
using PageObjectTests.pages.productsPages;
using PageObjectTests.services;

namespace PageObjectTests.pages.productCategoryPages;

public class GearPage : BasePage
{
    private readonly By _bagsLinkLocator = By.XPath("//span[@class ='count']/preceding-sibling::*[text() = 'Bags']");
    public GearPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
    }

    public BagsPage FollowToBagsPage()
    {
        waitService.waitForVisability(_bagsLinkLocator).Click();
        return new BagsPage(driver, waitService);
    }
}