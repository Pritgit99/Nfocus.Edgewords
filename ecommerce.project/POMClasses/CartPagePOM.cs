using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.project.POMClasses
{
    internal class CartPagePOM
    {
        private IWebDriver _driver; //field to hold webdriver instance
        private readonly By subtotal = By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-subtotal > td > span");
        private readonly By currentDiscount = By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-discount.coupon-edgewords > td > span");


        public CartPagePOM(IWebDriver driver) //get the webdriver instance from the calling test
        {
            this._driver = driver;
        }

        //Locators
        IWebElement couponField => _driver.FindElement(By.Id("coupon_code"));
        IWebElement applyCoupon => _driver.FindElement(By.Name("apply_coupon"));
        IWebElement GoToCheckout => _driver.FindElement(By.LinkText("Proceed to checkout"));


        //service method
        public void SetCoupon(string coupon_code) //Clicks on the coupon field and applies the discount
        {
            couponField.Clear();
            couponField.SendKeys(coupon_code);
        }

        public void ApplyCoupon()
        {
            applyCoupon.Click();
        }

        public void ProceedToCheckout()
        {
            GoToCheckout.Click();
        }

        public double GetSubtotal() //Gets the subtotal value on the website and stores it as a double
        {
            IWebElement getsubtotal = _driver.FindElement(subtotal);
            string newSubtotal = getsubtotal.Text;
            string newsubtotal = newSubtotal[1..];
            double finalsubtotal = double.Parse(newsubtotal);
            return finalsubtotal;
        }

        public double GetCurrentDiscount() //Gets the current discount figure and stores it as a double
        {
            IWebElement getcoupon = _driver.FindElement(currentDiscount);
            string coupondiscount = getcoupon.Text; 
            string newcoupon = coupondiscount[1..];
            double finalcoupon = double.Parse(newcoupon);
            return finalcoupon;
        }

    }
}