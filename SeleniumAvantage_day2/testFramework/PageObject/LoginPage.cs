using AventStack.ExtentReports;
using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testFramework.PageObject
{
    public class LoginPage : WebDriverAction
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly string tfUserName = "//input[@name='uid']";

        public void inputUserName(string UserName)
        {
            SendKeys_(tfUserName, UserName);
        }


    }
}
