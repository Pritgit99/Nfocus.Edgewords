using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.project.POMClasses
{
    internal class CheckoutPagePOM
    {
        private IWebDriver _driver;
        public CheckoutPagePOM(IWebDriver driver) //get the webdriver instance from the calling test
        {
            this._driver = driver;
        }

        //Locators

        IWebElement firstNameField => _driver.FindElement(By.Id("billing_first_name")); //These IWebElements finds the designated fields/elements
        IWebElement lastNameField => _driver.FindElement(By.Id("billing_last_name"));
        IWebElement companyNameField => _driver.FindElement(By.Id("billing_company"));
        IWebElement addressField1 => _driver.FindElement(By.Id("billing_address_1"));
        IWebElement addressField2 => _driver.FindElement(By.Id("billing_address_2"));
        IWebElement cityField => _driver.FindElement(By.Id("billing_city"));
        IWebElement countyField => _driver.FindElement(By.Id("billing_state"));
        IWebElement postcodeField => _driver.FindElement(By.Id("billing_postcode"));
        IWebElement phoneNumberField => _driver.FindElement(By.Id("billing_phone"));
        IWebElement emailField => _driver.FindElement(By.Id("billing_email"));
        IWebElement differentShippingField => _driver.FindElement(By.Name("ship_to_different_address"));
        IWebElement orderCommentsField => _driver.FindElement(By.Id("order_comments"));
        IWebElement checkPaymentField => _driver.FindElement(By.CssSelector("#payment > ul > li.wc_payment_method.payment_method_cheque > label"));
        IWebElement placeOrderButton => _driver.FindElement(By.Name("woocommerce_checkout_place_order"));



        //service method


        public void SetFirstName(string billing_first_name) //Clears the first name field and sets the value
        {
            firstNameField.Clear();
            firstNameField.SendKeys(billing_first_name);
        }

        public void SetLastName(string billing_last_name)
        {
            lastNameField.Clear();
            lastNameField.SendKeys(billing_last_name);
        }

        public void SetCompanyName(string billing_company_name)
        {
            companyNameField.Clear();
            companyNameField.SendKeys(billing_company_name);
        }

        public void SetAddressLine1(string billing_address_line1)
        {
            addressField1.Clear();
            addressField1.SendKeys(billing_address_line1);
        }


        public void SetAddressLine2(string billing_address_line2)
        {
            addressField2.Clear();
            addressField2.SendKeys(billing_address_line2);
        }


        public void SetBillingCity(string billing_city)
        {
            cityField.Clear();
            cityField.SendKeys(billing_city);
        }

        public void SetCounty(string billing_state)
        {
            countyField.Clear();
            countyField.SendKeys(billing_state);
        }

        public void SetPostcode(string billing_postcode)
        {
            postcodeField.Clear();
            postcodeField.SendKeys(billing_postcode);
        }

        public void SetPhoneNumber(string billing_phone)
        {
            phoneNumberField.Clear();
            phoneNumberField.SendKeys(billing_phone);
        }

        public void SetEmail(string billing_email)
        {
            emailField.Clear();
            emailField.SendKeys(billing_email);
        }

        public void ClickDifferentShippingAddress()
        {
            differentShippingField.Click();
        }

        public void SetOrderComents(string order_comments)
        {
            orderCommentsField.Clear();
            orderCommentsField.SendKeys(order_comments);
        }

        public void CheckPayment()
        {
            checkPaymentField.Click();
        }

        public void ClickPlaceOrder()
        {
            placeOrderButton.Click();
        }

    }
}
