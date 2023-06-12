using NUnit.Framework;

namespace PageObjectTests.tests;

[TestFixture]
public class MagentoTests : BaseTest
{
    private Random random = new Random();
    
   [Test]
   [Property("WithoutLogOut","true")]
   public void FirstScenario()
    {
       var actualOrder =
       mainPage.ClickSignInButton()
           .InputCredentials
           (ConfigurationManager.AppSetting["email"],
            ConfigurationManager.AppSetting["password"])
            .ClickSingInButton()
            .MoveToGearAndClickWatchesLink()
            .AddItemToTheCart()
            .ProceedToCheckout()
            .AddOrderData("Spur Road", "London", "16545-6999", random.Next(10000000, 100000000))
            .ClickPlaceOrderButton()
            .ClickContinueButton()
            .GoToAccount()
            .GoToOder();
       
       Assert.That(actualOrder.ProductName, Is.EqualTo("Dash Digital Watch"));
       Assert.That(actualOrder.Subtotal, Is.EqualTo("$92.00"));
       Assert.That(actualOrder.ShippingAndHanding, Is.EqualTo("$5.00"));
       Assert.That(actualOrder.GrandTotal, Is.EqualTo("$97.00"));
    }

    [Test]
    [Property("WithoutLogOut","false")]
    public void SecondScenario()
    {
        string actualResult = mainPage.FollowToCreationOfAccount()
            .CreateAccount("Tom","Johnson","Q@12345678q");
        
        Assert.AreEqual("This is a required field.", actualResult);
    }

    [Test]
    [Property("WithoutLogOut","true")]
    public void ThirdScenario()
    {
        var actualNumber = mainPage.ClickSignInButton()
                .InputCredentials
                (ConfigurationManager.AppSetting["email"],
                    ConfigurationManager.AppSetting["password"])
                .ClickSingInButton()
                .ClickOnGear()
                .FollowToBagsPage()
                .AddItemsToTheCart()
                .AddBagsToTheCart()
                .GetTheCartNumber();
        Assert.AreEqual("3", actualNumber);
    }
}