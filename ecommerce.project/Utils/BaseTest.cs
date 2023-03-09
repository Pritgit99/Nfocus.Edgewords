using ecommerce.project.POMClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.project.Utils
{
    internal class BaseTest
    {
        protected IWebDriver driver;
        protected string baseUrl;
        protected string browser;


        [SetUp]
        public void Setup()
        {
            browser = TestContext.Parameters["browser"];
            Console.WriteLine("Read in browser var from command line: " + browser);
           // browser = browser.ToLower().Trim(); //works in cmd but not right click run in vs
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver(); break;
                case "firefox":
                    driver = new FirefoxDriver(); break;
                default:
                    Console.WriteLine("Unknown browser, starting chrome");
                    driver = new ChromeDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Url = "https://www.edgewordstraining.co.uk/demo-site"; //Sets the base url

            HomePagePOM homePage = new HomePagePOM(driver);

            homePage.MyAccountPage();

            LoginPagePOM loginPage = new LoginPagePOM(driver);

            loginPage.SetUsername("pritesh.panchal@nfocus.co.uk");
            string login_password = Environment.GetEnvironmentVariable("loginpassword"); //Using an environment variable to get the password for security and data protection
            var passwordField = driver.FindElement(By.Id("password"));
            driver.FindElement(By.Id("password")).SendKeys(login_password);
            loginPage.ClickLogin();
            //Have an assertion that we logged in

            MyAccountPagePOM goToShopPage = new MyAccountPagePOM(driver);
            goToShopPage.GoToShop();
            //Have an assertion that we are on shop page

        }

        [TearDown]
        public void TearDown()
        {
            MyAccountPagePOM logOut = new MyAccountPagePOM(driver);
            logOut.Logout();
            //driver.Quit();
        }
    }
}
