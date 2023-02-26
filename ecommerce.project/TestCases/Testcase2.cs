using ecommerce.project.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.project.TestCases
{
    internal class Testcase2 :BasePOM
    {
        [Test]
        public void PlaceOrder()
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,550)", "");

            driver.FindElement(By.LinkText("Proceed to checkout")).Click();

            js.ExecuteScript("window.scrollBy(0,400)", "");

            driver.FindElement(By.Id("billing_first_name")).Click();            //change all of this to get innput from user and store in variable
            driver.FindElement(By.Id("billing_first_name")).Clear();
            driver.FindElement(By.Id("billing_first_name")).SendKeys("Pritesh");
            driver.FindElement(By.Id("billing_last_name")).Click();
            driver.FindElement(By.Id("billing_last_name")).Clear();
            driver.FindElement(By.Id("billing_last_name")).SendKeys("Panchal");
            driver.FindElement(By.Id("billing_company")).Click();
            driver.FindElement(By.Id("billing_company")).Clear();
            driver.FindElement(By.Id("billing_company")).SendKeys("Nfocus");
            driver.FindElement(By.Id("billing_address_1")).Click();
            driver.FindElement(By.Id("billing_address_1")).Clear();
            driver.FindElement(By.Id("billing_address_1")).SendKeys("e-Innovation Centre Telford"); //doesnt work in firefox
            driver.FindElement(By.Id("billing_city")).Click();
            driver.FindElement(By.Id("billing_city")).Clear();
            driver.FindElement(By.Id("billing_city")).SendKeys("Telford");
            js.ExecuteScript("window.scrollBy(0,500)", "");
            driver.FindElement(By.Id("billing_postcode")).Click();
            driver.FindElement(By.Id("billing_postcode")).Clear();
            driver.FindElement(By.Id("billing_postcode")).SendKeys("TF2 9FT");
            driver.FindElement(By.Id("billing_phone")).Click();
            driver.FindElement(By.Id("billing_phone")).Clear();
            driver.FindElement(By.Id("billing_phone")).SendKeys("0370 242 6235");
            driver.FindElement(By.Id("billing_email")).Click();
            driver.FindElement(By.Id("billing_email")).Clear();
            driver.FindElement(By.Id("billing_email")).SendKeys("pritesh.panchal@nfocus.co.uk");
            driver.FindElement(By.CssSelector("#payment > ul > li.wc_payment_method.payment_method_cheque > label")).Click();
            driver.FindElement(By.Id("place_order")).Click();



            IWebElement getordernumber = driver.FindElement(By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order > strong"));
            string ordernumber = getordernumber.Text;


            

            driver.FindElement(By.LinkText("My account")).Click();
            driver.FindElement(By.LinkText("Orders")).Click();

            IWebElement geto1 = driver.FindElement(By.CssSelector("#post-7 > div > div > div > table"));
            string pastorders = geto1.Text;


            Assert.IsTrue(pastorders.Contains(ordernumber));

            Console.WriteLine(ordernumber);
            //js.ExecuteScript("window.scrollBy(0,500)", ""); //needed when window is not maximised

            //logs out
            driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--customer-logout > a")).Click();


        }
    }
}
