using FluentAssertions;
using SpecFlowFramework.StepDefinitions;
using SpecFlowProjectFramework.Configurations;
using System;
using TechTalk.SpecFlow;
using SpecflowProjectFramework.PageObjects;

namespace SpecflowProjectFramework.StepDefinition
{
    [Binding]
    public class MetalWatchPurchaseSteps:CommonStepDefinitions
    {
        public MetalWatchPurchaseSteps(GlobalSettings settings): base(settings) { }

        [Given(@"I am on the Magento Home Page")]
        public void GivenIAmOnTheMagentoHomePage()
        {
            var homePage = new HomePage(Settings);
            homePage.NavigateToApplication();
        }

        [Then(@"I should see the signin button on the home page")]
        public void ThenIShouldSeeTheSigninButtonOnTheHomePage()
        {
            var homePage = new HomePage(Settings);
            bool signInButton = homePage.VerifySIgnInButton();
            signInButton.Should().BeTrue("Sign button should be displayed in the Home Page");

        }

        [When(@"I click on the signin button on the home page")]
        public void WhenIClicksOnTheSigninButtonOnTheHomePage()
        {
            var homePage = new HomePage(Settings);
            homePage.ClickOnHomePageSIgnInButton();
        }

        [Then(@"I should be redirected to the login screen")]
        public void ThenIShouldBeRedirectedToTheLoginScreen()
        {
            var loginPage = new LoginPage(Settings);
            bool emailTextBox = loginPage.VerifyEmailTextBox();
            emailTextBox.Should().BeTrue("email text box should be displayed in the customer login screen ");
        }

        [When(@"I enter the email ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEntersTheEmailAndPassword(string email, string password)
        {
            var loginPage = new LoginPage(Settings);
            loginPage.EnterEmail(email);
            loginPage.EnterPassword(password);
        }

        [When(@"I click on the signin button")]
        public void WhenIClickOnTheSign_InButton()
        {
            var loginPage = new LoginPage(Settings);
            loginPage.ClickOnSIgnInButton();
        }

        [Then(@"I should see the welcome text on the home page")]
        public void ThenIShouldSeeTheWelcomeTextOnTheHomePage()
        {
            var homePage = new HomePage(Settings);
            homePage.VerifyWelcomeText().Should().BeTrue("Welcome text should be displayed after sign into the application");
        }

        [Then(@"I should not see the welcome text on the home page")]
        public void ThenIShouldNotSeeTheWelcomeTextOnTheHomePage()
        {
            var homePage = new HomePage(Settings);
            homePage.VerifyWelcomeText().Should().BeFalse("Welcome text should be displayed after sign into the application");
        }


        [When(@"I click on the ""([^""]*)"" item")]
        public void WhenIClickOnTheItem(string menuItem)
        {
            var homePage = new HomePage(Settings);
            homePage.ClickOnMenuItem(menuItem);
        }

        [When(@"I click on the submenu ""([^""]*)"" item")]
        public void IClickOnTheSubmenuItem(string subMenuItem)
        {
            var homePage = new HomePage(Settings);
            homePage.ClickOnSubMenuItem(subMenuItem);
        }



        [Then(@"I should see available shopping options")]
        public void ThenIShouldSeeAvailableShoppingOptions()
        {
            var productsPage= new MetalWatchProductPage(Settings);
            productsPage.ShoppingOptionsCount().Should().BeGreaterThan(0);
        }

        [When(@"I select the ""([^""]*)"" category")]
        public void WhenISelectTheCategory(string category)
        {
            var productsPage = new MetalWatchProductPage(Settings);
            productsPage.ClickOnShoppingOptionsByCategory(category);
            
        }

        [When(@"I filter by ""([^""]*)""")]
        public void WhenIFilterBy(string subCategory)
        {
            var productsPage = new MetalWatchProductPage(Settings);
            productsPage.ClickOnShoppingOptionsBySubCategory(subCategory);
        }

        [Then(@"I should see the product ""([^""]*)"" in the product list")]
        public void ThenIShouldSeeTheProductInTheProductList(string productName)
        {
            var productsPage = new MetalWatchProductPage(Settings);
            productsPage.VerifyProductName(productName).Should().BeTrue($"{productName} should be displayed");
            Settings.Scenario["productName"] = productName;
        }
        [Then(@"I should not see the product ""([^""]*)"" in the product list")]
        public void ThenIShouldNotSeeTheProductInTheProductList(string productName)
        {
            var productsPage = new MetalWatchProductPage(Settings);
            productsPage.VerifyProductName(productName).Should().BeFalse($"{productName} should be displayed");
            Settings.Scenario["productName"] = productName;
        }

        [When(@"I click on the product ""([^""]*)""")]
        public void WhenIClickOnTheProduct(string productName)
        {
            var productsPage = new MetalWatchProductPage(Settings);
            productsPage.ClickOnProductName(productName);
        }

        [Then(@"I should be directed to the product details page")]
        public void ThenIShouldBeDirectedToTheProductDetailsPage()
        {
            var productDetailsPage=new ProductDescriptionPage(Settings);
            productDetailsPage.GetProductNameTitle().Should().NotBeNullOrEmpty();
        }

        [Then(@"I should see the product name ""([^""]*)""")]
        public void ThenIShouldSeeTheProductName(string productName)
        {
            var productDetailsPage = new ProductDescriptionPage(Settings);
            productDetailsPage.GetProductNameTitle().Should().Be(productName);
        }

        [Then(@"I should get the quantity and price for the product ""([^""]*)""")]
        public void ThenIShouldGetTheQuantityAndPriceForTheProduct(string productName)
        {
            var productDetailsPage = new ProductDescriptionPage(Settings);
            string quantityInCart = productDetailsPage.GetQunatityInCartPage();
            quantityInCart.Should().Be("1");
            string priceInCartPage = productDetailsPage.GetPriceInCartPage();
            Settings.Scenario["priceInCartPage"] = priceInCartPage;
            decimal priceInCart = decimal.Parse(new string(priceInCartPage.Where(c => char.IsDigit(c) || c == '.').ToArray()));
            Settings.Scenario["priceInCart"] = priceInCart;
        }

        [When(@"I add the product to the cart")]
        public void WhenIAddTheProductToTheCart()
        {
            var productDetailsPage = new ProductDescriptionPage(Settings);
            productDetailsPage.VerifyAddToCartButton().Should().BeTrue();
            productDetailsPage.ClickOnAddToCartButton();
        }

        [Then(@"A success message should confirm that the product ""([^""]*)"" is added to the cart")]
        public void ThenASuccessMessageShouldConfirmThatTheProductIsAddedToTheCart(string productName)
        {
            var productDetailsPage = new ProductDescriptionPage(Settings);
            productDetailsPage.GetSuccessMessage().Should().Be($"You added {productName} to your shopping cart.");
        }

        [When(@"I navigate to the shopping cart page")]
        public void WhenUserNavigatesToTheShoppingCartPage()
        {
            var productDetailsPage = new ProductDescriptionPage(Settings);
            productDetailsPage.ClickOnShoppingCartLink();
        }

        [Then(@"I should see the product ""([^""]*)"" in the shopping cart")]
        public void ThenIShouldSeeTheProductInTheShoppingCart(string productName)
        {
            var shoppingCartPage = new MetalWatchCartPage(Settings);
            shoppingCartPage.VerifyShoppingCartTable().Should().BeTrue();
            shoppingCartPage.VerifyProductNameInCheckOutPage(productName).Should().BeTrue();
        }



        [Then(@"I should validate the quantity of the product ""([^""]*)"" in the shopping cart")]
        public void ThenIShouldValidateTheQuantityOfTheProductInTheShoppingCart(string productName)
        {
            var shoppingCartPage = new MetalWatchCartPage(Settings);
            string quantityInShoppingCartPage = shoppingCartPage.GetQuantityInShoppingCartPage(productName);
            quantityInShoppingCartPage.Should().NotBe("0");
            int noOfquantities = int.Parse(quantityInShoppingCartPage);
            Settings.Scenario["quantityInShoppingCartPage"] = quantityInShoppingCartPage;
            Settings.Scenario["noOfquantities"] = noOfquantities;

        }

        [Then(@"I should validate the product ""([^""]*)"" price in the shopping cart")]
        public void ThenIShouldValidateTheProductPriceInTheShoppingCart(string productName)
        {
            var shoppingCartPage = new MetalWatchCartPage(Settings);
            string priceInShoppingCart = shoppingCartPage.GetPriceInShoppingCartPage(productName);
            Settings.Scenario["priceInCartPage"].Should().Be(priceInShoppingCart);
            decimal price = decimal.Parse(new string(priceInShoppingCart.Where(c => char.IsDigit(c) || c == '.').ToArray()));
            Settings.Scenario["price"] = price;
        }

        [Then(@"I should validate the product ""([^""]*)"" subtotal in the shopping cart")]
        public void ThenIShouldValidateTheProductSubtotalInTheShoppingCart(string productName)
        {
            var shoppingCartPage = new MetalWatchCartPage(Settings);
            string subTotalInShoppingCartPage = shoppingCartPage.GetSubTotalInShoppingCartPage(productName);
            decimal subTotalInShoppingCart = decimal.Parse(new string(subTotalInShoppingCartPage.Where(c => char.IsDigit(c) || c == '.').ToArray()));
            decimal totalPrice = int.Parse(Settings.Scenario["quantityInShoppingCartPage"].ToString()) * decimal.Parse(Settings.Scenario["price"].ToString());
            totalPrice.Should().Be(subTotalInShoppingCart);
            Settings.Scenario["subTotalInShoppingCartPage"] = subTotalInShoppingCartPage;
            Settings.Scenario["subTotalInShoppingCart"] = subTotalInShoppingCart;
            Settings.Scenario["totalPrice"] = totalPrice;
        }

        [When(@"I update the quantity of ""([^""]*)"" to ""([^""]*)""")]
        public void WhenIUpdateTheQuantityOfTo(string productName, string quantities)
        {
            var shoppingCartPage = new MetalWatchCartPage(Settings);
            int increaseQuantity = int.Parse(quantities);
            int noOfquantities = int.Parse(Settings.Scenario["noOfquantities"].ToString());
            string quantity = (noOfquantities + increaseQuantity).ToString();
            shoppingCartPage.UpdatequnatityInCheckoutPage(productName, quantity);
        }

        [When(@"I click on the updateshoppingcart button")]
        public void WhenIClickOnTheUpdateshoppingcartButton()
        {
            var shoppingCartPage = new MetalWatchCartPage(Settings);
            shoppingCartPage.ClickOnUpdateShoppingCart();
        }

        [Then(@"The new quantity in the cart should be ""([^""]*)"" for the product ""([^""]*)""")]
        public void ThenTheNewQuantityInTheCartShouldBeForTheProduct(string updatedQuantity,string productName)
        {
            var shoppingCartPage = new MetalWatchCartPage(Settings);
            int increaseQuantity = int.Parse(updatedQuantity);
            int noOfquantities = int.Parse(Settings.Scenario["noOfquantities"].ToString());
            string increasedquantityInShoppingCartPage = shoppingCartPage.GetQuantityInShoppingCartPage(productName);
            Settings.Scenario["increasedquantityInShoppingCartPage"] = increasedquantityInShoppingCartPage;
            int noOfQuantitiesAfterIncreasedquantityInShoppingCart = int.Parse(increasedquantityInShoppingCartPage);
            noOfQuantitiesAfterIncreasedquantityInShoppingCart.Should().Be((noOfquantities + increaseQuantity));
            Settings.Scenario["noOfQuantitiesAfterIncreasedquantityInShoppingCart"] = noOfQuantitiesAfterIncreasedquantityInShoppingCart;
            Settings.Scenario["increaseQuantity"] = increaseQuantity;
        }
        [Then(@"The subtotal price should reflect the updated quantity for the product ""([^""]*)""")]
        public void ThenTheSubtotalPriceShouldReflectTheUpdatedQuantityForTheProduct(string productName)
        {
            var shoppingCartPage = new MetalWatchCartPage(Settings);
            string afterIncreasedSubTotalInShoppingCartPage = shoppingCartPage.GetSubTotalInShoppingCartPage(productName);
            decimal afterIncreasedSubTotalInShoppingCart = decimal.Parse(new string(afterIncreasedSubTotalInShoppingCartPage.Where(c => char.IsDigit(c) || c == '.').ToArray()));
            int noOfQuantitiesAfterIncreasedquantityInShoppingCart = int.Parse(Settings.Scenario["noOfQuantitiesAfterIncreasedquantityInShoppingCart"].ToString());
            decimal price= decimal.Parse(Settings.Scenario["price"].ToString());
            int increaseQuantity = int.Parse(Settings.Scenario["increaseQuantity"].ToString());
            decimal totalPriceAfterIncreasedQuantity = noOfQuantitiesAfterIncreasedquantityInShoppingCart * price ;
            decimal totalPrice=decimal.Parse(Settings.Scenario["totalPrice"].ToString());
            totalPriceAfterIncreasedQuantity.Should().Be(totalPrice + increaseQuantity * price);
            Settings.Scenario["afterIncreasedSubTotalInShoppingCartPage"] = afterIncreasedSubTotalInShoppingCartPage;
        }

        [Then(@"The order Total price should reflect the updated quantity for the product ""([^""]*)""")]
        public void ThenTheOrderTotalPriceShouldReflectTheUpdatedQuantityForTheProduct(string productName)
        {
            var shoppingCartPage = new MetalWatchCartPage(Settings);
            string orderTotal = shoppingCartPage.GetOrderTotal();
            decimal orderTotalValue = decimal.Parse(new string(orderTotal.Where(c => char.IsDigit(c) || c == '.').ToArray()));
            orderTotalValue.Should().NotBe(0);
            Settings.Scenario["orderTotal"] = orderTotal;
        }

        [When(@"I Click on proceed to checkout")]
        public void WhenIClickOnProceedToCheckout()
        {
            var shoppingCartPage = new MetalWatchCartPage(Settings);
            shoppingCartPage.ClickOnProceedToCheckOut();
        }

        [Then(@"I should see the number of items in the cart in the order summary")]
        public void ThenIShouldSeeTheNumberOfItemsInTheCartInTheOrderSummary()
        {
            var checkoutPage=new MetalWatchCheckoutPage(Settings);
            string increasedquantityInShoppingCartPage=Settings.Scenario["increasedquantityInShoppingCartPage"].ToString();
            increasedquantityInShoppingCartPage.Should().Be(checkoutPage.GetQuantitiesInCheckOutPage());
        }

        [When(@"I click on the number of items in the cart")]
        public void WhenIClickOnTheNumberOfItemsInTheCart()
        {
            var checkoutPage = new MetalWatchCheckoutPage(Settings);
            checkoutPage.ClickOnQuantitiesInCheckOutPage();
        }

        [Then(@"I should see the product ""([^""]*)"" in the order summary")]
        public void ThenIShouldSeeTheProductInTheOrderSummary(string productName)
        {
            var checkoutPage = new MetalWatchCheckoutPage(Settings);
            checkoutPage.GetProductNameInCheckOutPage().Should().Be(productName);
        }

        [Then(@"I should validate the product ""([^""]*)"" price in the order summary")]
        public void ThenIShouldValidateTheProductPriceInTheOrderSummary(string productName)
        {
            var checkoutPage = new MetalWatchCheckoutPage(Settings);
            string afterIncreasedSubTotalInShoppingCartPage= Settings.Scenario["afterIncreasedSubTotalInShoppingCartPage"].ToString();
            checkoutPage.GetPriceInOrderSummary(productName).Should().Be(afterIncreasedSubTotalInShoppingCartPage);
        }

        [When(@"I choose the shipping method ""([^""]*)""")]
        public void WhenIChooseTheShippingMethod(string shippingMethod)
        {
            var checkoutPage = new MetalWatchCheckoutPage(Settings);
            checkoutPage.ClickOnShippingMethod();
        }

        [When(@"I click on the next button")]
        public void WhenUserClicksOnTheNextButton()
        {
            var checkoutPage = new MetalWatchCheckoutPage(Settings);
            checkoutPage.ClickOnNextButton();
            checkoutPage.WaitForLoader();
        }

        [Then(@"I should validate order summary details in the Review Page")]
        public void ThenIShouldValidateOrderSummaryDetailsInTheReviewPage()
        {
            var reviewPage = new MetalWatchPaymentAndReviewPage(Settings);
            reviewPage.VerifyPaymentMethodPage().Should().BeTrue();
            reviewPage.GetCartSubTotalInOrderSummary().Should().Be(Settings.Scenario["afterIncreasedSubTotalInShoppingCartPage"].ToString());
            reviewPage.GetShippingMethod().Should().Be("Best Way - Table Rate");
            reviewPage.GetShippingTotalPrice().Should().Be("$0.00");
            reviewPage.GetOrderTotal().Should().Be(Settings.Scenario["orderTotal"].ToString());
            var checkOutPage=new MetalWatchCheckoutPage(Settings);
            checkOutPage.GetProductNameInCheckOutPage().Should().Be(Settings.Scenario["productName"].ToString());
            string increasedquantityInShoppingCartPage = Settings.Scenario["increasedquantityInShoppingCartPage"].ToString();
            reviewPage.GetQuantityInOrderSUmmaryPage().Should().Be(increasedquantityInShoppingCartPage);
            string afterIncreasedSubTotalInShoppingCartPage = Settings.Scenario["afterIncreasedSubTotalInShoppingCartPage"].ToString();
            reviewPage.GetPriceInOrderSUmmaryPage().Should().Be(afterIncreasedSubTotalInShoppingCartPage);
 
        }

        [When(@"I click on place order")]
        public void WhenIClickOnPlaceOrder()
        {
            var reviewPage = new MetalWatchPaymentAndReviewPage(Settings);
            reviewPage.ClickOnPlaceOrder();
        }

        [Then(@"I should be able to place the order successfully")]
        public void ThenIShouldBeAbleToPlaceTheOrderSuccessfully()
        {
            var orderConfirmationPage = new MetalWatchOrderConfirmationPage(Settings);
            orderConfirmationPage.GetOrderNo().Should().NotBeNullOrEmpty();
        }

    }
}
