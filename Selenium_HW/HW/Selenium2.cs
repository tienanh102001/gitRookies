using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;
using System;

namespace Selenium2
{
    [TestFixture]
    public class Tests
    {
        protected IWebDriver driver;
        protected WebDriverWait? wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Window.Maximize();

            Console.WriteLine("The website is opened successfully");

            driver.FindElement(By.Id("contact-link")).Click();

            string actualTL1 = driver.Title;
            string expectedTL1 = "Contact us - My Store";

            Assert.That(actualTL1, Is.EqualTo(expectedTL1));

            driver.Navigate().Back();

            string actualTL2 = driver.Title;
            string expectedTL2 = "My Store";

            Assert.That(actualTL2, Is.EqualTo(expectedTL2));

            driver.Navigate().Forward();
            driver.Close();
            driver.Quit();
        }
    }
}
