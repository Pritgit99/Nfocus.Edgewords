using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.project.POMClasses
{
    internal class OrdersPagePOM
    {
        private IWebDriver _driver; //field to hold webdriver instance

        public OrdersPagePOM(IWebDriver driver) //get the webdriver instance from the calling test
        {
            this._driver = driver;
        }

        //Locators
        IWebElement logOut => _driver.FindElement(By.LinkText("Logout"));


        public void Logout()
        {
            logOut.Click();
        }

        public IWebElement PastOrders => _driver.FindElement(By.CssSelector("#post-7 > div > div > div > table"));


    }
}

