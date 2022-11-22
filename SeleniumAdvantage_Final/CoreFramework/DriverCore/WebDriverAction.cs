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

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public string GetTitle()
        {
            return driver.Title;
        }
        public string GetTitle(IWebDriver _driver)
        {
            return _driver.Title;
        }

        public void CompareTitle(string expected)
        {
            try
            {
                string actual = GetTitle();
                Assert.That(actual, Is.EqualTo(expected));
                TestContext.Write("CompareTitle " + expected.ToString() + " passed ");
                HtmlReport.Pass("CompareTitle " + expected.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("CompareTitle " + expected.ToString() + " failed ");
                HtmlReport.Fail("CompareTitle " + expected.ToString() + " failed", TakeScreenshot());
                throw ex;
            }
        }
        public void CompareUrl(string expected)
        {
            try
            {
                string actual = GetUrl().ToString();
                Assert.That(actual, Is.EqualTo(expected));
                TestContext.Write("Direct to correct link: " + expected.ToString() + " passed ");
                HtmlReport.Pass("Direct to correct link: " + expected.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("Direct to correct link: " + expected.ToString() + " failed ");
                HtmlReport.Fail("Direct to correct link: " + expected.ToString() + " failed", TakeScreenshot());
                HtmlReport.Fail("Direct to correct link: " + expected.ToString() + " failed", TakeScreenshot());
                throw ex;
            }
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
        public int RowTable(string locator)
        {
            int row = driver.FindElements(ByXpath(locator)).Count;
            TestContext.Write("The number of row is " + row);
            return row;
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
                HtmlReport.Pass("click into element " + e.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("click into element " + e.ToString() + " failed");
                HtmlReport.Pass("click into element " + e.ToString() + " failed");
                throw ex;
            }
        }

        public void Click(string locator)
        {
            try
            {
                FindElementByXpath(locator).Click();
                TestContext.Write("click into element " + locator + " passed");
                HtmlReport.Pass("click into element " + locator + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("click into element " + locator + " failed");
                HtmlReport.Pass("click into element " + locator + " passed");
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
                HtmlReport.Fail("sendkeys into element " + locator + " failed", TakeScreenshot());
                throw ex;
            }
        }

        public string TakeScreenshot()
        {
            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMdd")) + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
        public string GetUrl()
        {
            string Url = driver.Url;
            return Url;
        }
        
        
    }
}
