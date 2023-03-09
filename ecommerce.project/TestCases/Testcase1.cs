using ecommerce.project.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ecommerce.project.TestCases
{
    internal class Testcase1 : BaseTest
    {

        [Test]
        public void Discount()
        {

            driver.FindElement(By.Id("coupon_code")).Click();
            driver.FindElement(By.Id("coupon_code")).SendKeys("edgewords");
            driver.FindElement(By.Name("apply_coupon")).Click();

            //Finds subtotal text and stores it in 'getsubtotal'
            IWebElement getsubtotal = driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-subtotal > td > span"));
            string subtotal = getsubtotal.Text; // Get the text value of subtotal and stores it as a string in 'subtotal'
            string newsubtotal = subtotal[1..]; //removes the £ and stores it in 'newsubtotal'
            double finalsubtotal = double.Parse(newsubtotal); //converts to double value called 'finalsubtotal'



            //Finds websites discount text and stores it in 'getcoupon'
            IWebElement getcoupon = driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-discount.coupon-edgewords > td > span"));          
            string coupondiscount = getcoupon.Text; // Get the text value of coupon and stores it as a string in 'coupondiscount'
            string newcoupon = coupondiscount[1..]; //removes the £ and stores it in 'newcoupon'
            double finalcoupon = double.Parse(newcoupon); //converts to double value called 'finalcoupon'


            double percent = finalsubtotal * 0.15; //Calculates 15% of the total to get the correct discount
            double correctdiscount = Math.Round(percent, 2); //rounds the correct discount to 2 decimal points
            double websitediscount = Math.Round(finalcoupon, 2); //rounds the websites discount amount to 2 decimal points

           Assert.AreEqual(correctdiscount, websitediscount); //Checks the websites discount against the expected figure



            Console.WriteLine(correctdiscount);
            Console.WriteLine(websitediscount);
            //Console.WriteLine(formattedPercent);

            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(700,0)", "");

            driver.FindElement(By.LinkText("My account")).Click();
   
            //logs out
            driver.FindElement(By.CssSelector("#post-7 > div > div > div > p:nth-child(2) > a")).Click();

        }
    }
}
