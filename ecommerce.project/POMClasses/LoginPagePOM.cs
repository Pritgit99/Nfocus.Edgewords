using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.project.POMClasses
{
    internal class LoginPagePOM //Finds the login elements and sends the data accordingly
    {
        private IWebDriver _driver; //Field to hold a webdriver instance

        public LoginPagePOM(IWebDriver driver) //Get the webdriver instance from the calling test
        {
            this._driver = driver;
        }
        IWebElement usernameField => _driver.FindElement(By.Id("username"));
        IWebElement passwordField => _driver.FindElement(By.Id("password"));
        IWebElement loginButton => _driver.FindElement(By.Name("login"));

        public void SetUsername(string username)
        {
            usernameField.Clear();
            usernameField.SendKeys(username);
            //return this;
        }

        public void SetPassword(string password)
        {
            passwordField.Clear();
            passwordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            loginButton.Click();
        }

    }
}
