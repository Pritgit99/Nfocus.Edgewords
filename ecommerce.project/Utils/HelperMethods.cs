using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.project.Utils
{

    internal class HelperMethods
    {
        private IWebDriver _driver;

        public HelperMethods(IWebDriver driver)
        {
            this._driver = driver;
        }

        //public void WaitForElement(By locator, int timeToWaitInSeconds)
        //{
        //    WebDriverWait wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeToWaitInSeconds));
        //    wait2.Until(drv => drv.FindElement(locator).Displayed);
        //}

        //public static IWebElement WaitForElement(By locator, int timeToWaitInSeconds, IWebDriver driver)
        //{
        //    WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWaitInSeconds));
        //    return wait2.Until(drv => drv.FindElement(locator));
        //}

        //public static void TakeScreenshotOfElement(IWebDriver driver, By locator, string filename)
        //{
        //    IWebElement form = driver.FindElement(locator);

        //    ITakesScreenshot formss = form as ITakesScreenshot;
        //    var screenshotForm = formss.GetScreenshot();
        //    screenshotForm.SaveAsFile(@"D:\screenshots\" + filename, ScreenshotImageFormat.Png); //ToDo: Timstamp screenshots so they are not overwritten
        //    TestContext.WriteLine("Screenshot taken - see report");
        //    TestContext.AddTestAttachment(@"D:\screenshots\" + filename);
        //}
        
        //public waittime()
        //{
        //    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3);
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
        //    wait.Until(drv => drv.FindElement(By.LinkText("Log out")).Displayed);
        //}

    }
}
