using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.project.POMClasses
{
    internal class ShopPagePOM //This class allows users to add items to the cart and view them
    {
        private IWebDriver _driver;
        public ShopPagePOM(IWebDriver driver) //get the webdriver instance from the calling test
        {
            this._driver = driver;
        }

        //Locators

        IWebElement addToCart => _driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-27.status-publish.first.instock.product_cat-accessories.has-post-thumbnail.sale.shipping-taxable.purchasable.product-type-simple > a.button.product_type_simple.add_to_cart_button.ajax_add_to_cart"));
        IWebElement viewCart => _driver.FindElement(By.LinkText("View cart"));


        //service method

        public void AddToCart()
        {
            addToCart.Click();
        }

        public void ViewCart()
        {
            viewCart.Click();
        }
    }
}
