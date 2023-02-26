using ecommerce.project.POMClasses;
using ecommerce.project.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.project.POMTests
{
    internal class TestsUsingPOM : BasePOM
    {
        [Test]
        public void TestCase1()
        {

            CartPagePOM coupon = new CartPagePOM(driver);
            try //Try method to check if the current discount on the website is the correct one and if not then the ssertion is caught 
            {
                coupon.SetCoupon("edgewords"); //Sets the coupon value as edgewords
                coupon.ApplyCoupon();
   

                // Verify the coupon discount
                CartPagePOM cartPage = new CartPagePOM(driver);
                double subtotal = cartPage.GetSubtotal();
                double couponDiscount = cartPage.GetCurrentDiscount();

                // Calculate the expected discount and round to 2 decimal places
                double expectedDiscount = Math.Round(subtotal * 0.15, 2);

                // Check that the coupon discount matches the expected discount
                Assert.AreEqual(expectedDiscount, couponDiscount);
                Console.WriteLine(couponDiscount);
                Console.WriteLine(expectedDiscount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            HomePagePOM homePage = new HomePagePOM(driver);
            homePage.MyAccountPage();

            MyAccountPagePOM logOut = new MyAccountPagePOM(driver);
            logOut.Logout();

        }

        [Test]
        public void TestCase2()
        {

            var js = (IJavaScriptExecutor)driver; 
            js.ExecuteScript("window.scrollBy(0,450)", ""); //Scrolls down

            Thread.Sleep(1000);

            CartPagePOM goToCheckout = new CartPagePOM(driver);
            goToCheckout.ProceedToCheckout();

            CheckoutPagePOM orderDetails = new CheckoutPagePOM(driver); //Fill out personal details for order
            orderDetails.SetFirstName("Pritesh");
            orderDetails.SetLastName("Panchal");
            orderDetails.SetCompanyName("NFocus");
            orderDetails.SetAddressLine1("e-Innovation Centre Telford");
            orderDetails.SetAddressLine2("Telford");
            orderDetails.SetBillingCity("Telford");
            orderDetails.SetCounty("Telford");
            orderDetails.SetPostcode("TF2 9FT");
            orderDetails.SetPhoneNumber("0370 242 6235");
            orderDetails.SetEmail("pritesh.panchal@nfocus.co.uk");
            orderDetails.ClickDifferentShippingAddress();
            orderDetails.ClickDifferentShippingAddress();
            orderDetails.SetOrderComents("This is a test");
            orderDetails.CheckPayment();
            js.ExecuteScript("window.scrollBy(0,250)", "");
            orderDetails.ClickPlaceOrder();


            OrderConfirmedPagePOM orderConfirmationPage = new OrderConfirmedPagePOM(driver);
            try //Try-catch method to check if the order number on the confirmation page is the same as the order history
            {
                string orderNumber = orderConfirmationPage.GetOrderNumber();

                OrderConfirmedPagePOM goToMyAccount = new OrderConfirmedPagePOM(driver);
                goToMyAccount.AccountPage();

                MyAccountPagePOM goToOrder = new MyAccountPagePOM(driver);
                goToOrder.GoToOrder();

                OrdersPagePOM ordersPage = new OrdersPagePOM(driver);
                string pastorders = ordersPage.PastOrders.Text;
                Assert.IsTrue(pastorders.Contains(orderNumber));
                Console.WriteLine(pastorders);
                Console.WriteLine(orderNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed with error message: " + e.Message);
            }


            js.ExecuteScript("window.scrollBy(0,250)", "");

            OrdersPagePOM logOut = new OrdersPagePOM(driver);
            logOut.Logout();


        }

    }
}
    