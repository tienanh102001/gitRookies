using OpenQA.Selenium;
using SeleniumFramework.DriverCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFrame.DriverCore
{
    internal class WebDriverManager
    {
        private static AsyncLocal<IWebDriver> driver = new AsyncLocal<IWebDriver>();

        public static void InitDriver(String Browser, int width, int height)
        {
            IWebDriver newDriver = null;
            newDriver = WebDriverCreator.CreateLoacalDriver(Browser, width, height);

            if (newDriver == null)
                throw new Exception($"{Browser} browser is not supported");
            driver.Value = newDriver;
        }

        public static IWebDriver GetCurrentDriver()
        {
            return driver.Value;
        }
    }
}
