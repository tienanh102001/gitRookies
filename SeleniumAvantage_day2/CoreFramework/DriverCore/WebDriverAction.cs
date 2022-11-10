using AventStack.ExtentReports;
using CoreFramework.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;
        //private WebDriverWait explicitWait;

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public string getTitle()
        {
            return driver.Title;
        }

        public IWebElement FindElementByXpath(string locator)
        {
            IWebElement e = driver.FindElement(ByXpath(locator));
            highlightElement(e);
            return e;
        }

        public IList<IWebElement> FindElementsByXpath(string locator)
        {
            return driver.FindElements(ByXpath(locator));
        }

        public IWebElement highlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border='2px solid red'", element);
            return element;
        }

        public void Click(IWebElement e)
        {
            try
            {
                highlightElement(e);
                e.Click();
                TestContext.Write("click into element " + e.ToString() + " passed");
                //HtmlReporter.Pass("Clicked to element [" + e.ToString() + "]");
            }
            catch (Exception ex)
            {
                //string screenshot = TakeScreenshot();
                //HtmlReporter.Fail("Could not click to element [" + e.ToString() + "]");
                TestContext.Write("click into element " + e.ToString() + " failed");
                throw ex;
            }
        }

        public void Click(string locator)
        {
            try
            {
                FindElementByXpath(locator).Click();
                TestContext.Write("click into element " + locator + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("click into element " + locator + " failed");
                throw ex;
            }
        }

        public void SendKeys_(string locator, string key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                TestContext.Write("sendkeys into element " + locator + " passed");
                HtmlReport.Pass("sendkeys into element " + locator + " passed");
            }
            catch (Exception ex)
            {
                
                TestContext.Write("sendkeys into element " + locator + " failed");
                HtmlReport.Fail("sendkeys into element " + locator + " failed", TakeScreenShot());
                throw ex;
            }
        }
        public string TakeScreenShot()
        {
            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
    }
}
