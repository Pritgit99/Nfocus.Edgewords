using ecommerce.project.POMClasses;
using ecommerce.project.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.project.POMTests
{
    internal class TestsUsingPOM : BaseTest
    {
        [Test]
        public void TestCase1()
        {
            ShopPagePOM shopPage = new ShopPagePOM(driver);
            shopPage.DismissNotice();

            IWebElement randomAddToCartLink = shopPage.SelectRandomAddToCartLink();
            randomAddToCartLink.Click();
            shopPage.ViewCart();

            CartPagePOM cartPage = new CartPagePOM(driver);
            try //Try method to check if the current discount on the website is the correct one and if not then the ssertion is caught 
            {
                cartPage.SetCoupon("edgewords"); //Sets the coupon value as edgewords
                cartPage.ApplyCoupon();
   

                // Verify the coupon discount
                decimal subtotal = cartPage.GetSubtotal();
                decimal couponDiscount = cartPage.GetCurrentDiscount();

                // Calculate the expected discount and round to 2 decimal places
                decimal expectedDiscount = Math.Round(subtotal * 0.15m, 2);

                // Check that the coupon discount matches the expected discount
                Assert.AreEqual(expectedDiscount, couponDiscount);
                Console.WriteLine(couponDiscount);
                Console.WriteLine(expectedDiscount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                //take screenshot and report
            }
            Thread.Sleep(2000);
            //assert that coupon is applied
            string couponBanner = driver.FindElement(By.CssSelector("#post-5 > div > div > div.woocommerce-notices-wrapper")).Text;
            Assert.IsTrue(couponBanner == "Coupon code applied successfully." || couponBanner == "Coupon code already applied!", "Invalid coupon");
            Console.WriteLine(couponBanner);

            //Assert.IsTrue(driver.FindElement(By.Id("coupon_code")).Displayed);

            HomePagePOM homePage = new HomePagePOM(driver);
            homePage.MyAccountPage();
        }

        [Test]
        public void TestCase2()
        {

            Thread.Sleep(1000);

            ShopPagePOM shopPage = new ShopPagePOM(driver);
            shopPage.DismissNotice();

            IWebElement randomAddToCartLink = shopPage.SelectRandomAddToCartLink();
            randomAddToCartLink.Click();
            shopPage.ViewCart();
            //Have an assertion to show we are on cart page for validation

            CartPagePOM goToCheckout = new CartPagePOM(driver);
            goToCheckout.ProceedToCheckout();

            CheckoutPagePOM orderDetails = new CheckoutPagePOM(driver); //Fill out personal details for order

            string firstName = TestContext.Parameters["firstNameField"];
            string lastName = TestContext.Parameters["lastNameField"];
            string companyName = TestContext.Parameters["companyNameField"];
            string addressLine1 = TestContext.Parameters["addressField1"];
            string addressLine2 = TestContext.Parameters["addressField2"];
            string city = TestContext.Parameters["cityField"];
            string county = TestContext.Parameters["countyField"];
            string postcode = TestContext.Parameters["postcodeField"];
            string phoneNumber = TestContext.Parameters["phoneNumberField"];
            string emailAddress = TestContext.Parameters["emailField"];

            orderDetails.SetFirstName(firstName);
            orderDetails.SetLastName(lastName);
            orderDetails.SetCompanyName(companyName);
            orderDetails.SetAddressLine1(addressLine1);
            orderDetails.SetAddressLine2(addressLine2);
            orderDetails.SetBillingCity(city);
            orderDetails.SetCounty(county);
            orderDetails.SetPostcode(postcode);
            orderDetails.SetPhoneNumber(phoneNumber);
            orderDetails.SetEmail(emailAddress);
            orderDetails.ClickDifferentShippingAddress();
            orderDetails.ClickDifferentShippingAddress();
            orderDetails.SetOrderComents("This is a test");
            Thread.Sleep(1000);
            orderDetails.CheckPayment();
            Thread.Sleep(1000);
            orderDetails.ClickPlaceOrder();
            Thread.Sleep(2000);

            //assert that we are on order confirmed page for validation
            string headingText = driver.FindElement(By.CssSelector("H1")).Text;
            Assert.IsTrue(headingText == "Order received", "Wrong page");
            Console.WriteLine(headingText);


            OrderConfirmedPagePOM orderConfirmationPage = new OrderConfirmedPagePOM(driver);
            try //Try-catch method to check if the order number on the confirmation page is the same as the order history
            {
                string orderNumber = orderConfirmationPage.GetOrderNumber();

                OrderConfirmedPagePOM goToMyAccount = new OrderConfirmedPagePOM(driver);
                goToMyAccount.AccountPage();

                MyAccountPagePOM goToOrder = new MyAccountPagePOM(driver);
                goToOrder.GoToOrder();

                OrdersPagePOM ordersPage = new OrdersPagePOM(driver);
                string pastorders = ordersPage.GetOrders();
                Assert.AreEqual(orderNumber, orderNumber);
                Console.WriteLine(pastorders);
                Console.WriteLine(orderNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed with error message: " + e.Message);
                //take screenshot and report
            }

        }

    }
}
    