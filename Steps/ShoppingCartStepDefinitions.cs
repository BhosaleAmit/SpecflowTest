using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Steps
{
    [Binding]
    public sealed class ShoppingCartStepDefinitions
    {
        
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        int minRecord = 0;

        public ShoppingCartStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            //_scenarioContext.Pending();
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            //_scenarioContext.Pending();
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            //_scenarioContext.Pending();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            //_scenarioContext.Pending();
        }

        [Given(@"I add four different products to my wishlist")]
        public void GivenIAddFourDifferentProductsToMyWishlist()
        {
            WebElementExtension.findElementByConfig(@"//a[@data-product-id=17]//following::span", "XPath").Click();
            WebElementExtension.findElementByConfig(@"//a[@data-product-id=14]//following::span", "XPath").Click();
            WebElementExtension.findElementByConfig(@"//a[@data-product-id=20]//following::span", "XPath").Click();
            WebElementExtension.findElementByConfig(@"//a[@data-product-id=23]//following::span", "XPath").Click();

            //WebElementExtension.FindElementByConfig(@"(//span[contains(text(),'Add to wishlist')])[1]", "XPath").Click();
            //WebElementExtension.FindElementByConfig(@"(//span[contains(text(),'Add to wishlist')])[2]", "XPath").Click();

            //WebElementExtension.FindElementByConfig(@"(//span[contains(text(),'Add to wishlist')])[3]", "XPath").Click();
            //WebElementExtension.FindElementByConfig(@"//a[@data-product-id=23]//following::span", "XPath").Click();

            //WebElementExtension.FindElementByConfig(@"(//span[contains(text(),'Add to wishlist')])[5]", "XPath").Click();

        }

        [When(@"I view wishlist table")]
        public void WhenIViewWishlistTable()
        {
            WebElementExtension.findElementByConfig(@"//div[@class='header-wishlist']//i[contains(@class,'la-heart')]", "XPath").Click();

        }

        [Then(@"I find total four selected items in Wishlist")]
        public void ThenIFindTotalFourSelectedItemsInWishlist()
        {
            var count = WebElementExtension.getTableRowCount(@"//table[contains(@class,'shop_table cart wishlist')]", "XPath");

            count.Should().Be(5," with addition of header");
        }

        [When(@"I search for lowest price product")]
        public void WhenISearchForLowestPriceProduct()  
        {
            minRecord = WebElementExtension.iterateWishListTable(@"//table[contains(@class,'shop_table cart wishlist')]", "XPath"); ;

        }

        [When(@"I am able to add the lowest price item to my cart")]
        public void WhenIAmAbleToAddTheLowestPriceItemToMyCart()
        {
            var addLink = @"(//td[@class='product-add-to-cart'])[" + minRecord.ToString() + @"]/a[1]";
            WebElementExtension.findElementByConfig(addLink, "XPath").Click();
        }

        [Then(@"I am able to verify the item in my cart")]
        public void ThenIAmAbleToVerifyTheItemInMyCart()
        {
            WebElementExtension.findElementByConfig(@"//i[contains(@class,'la la-shopping-bag')]", "XPath").Click();

            var count = WebElementExtension.getTableRowCount(@"//table[contains(@class,'responsive cart')]", "XPath");

            count.Should().Be(3, " with addition of header & coupon code");
        }

    }//class end
}
