using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace Selenium3
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
            driver.Navigate().GoToUrl("http://google.com");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//input[@name=\"q\"]")).SendKeys("Facebook");
            driver.FindElement(By.XPath("//input[@name=\"q\"]")).SendKeys(Keys.Enter);

            string actualTL = driver.Title;
            string expectedTL = "Facebook";

            Assert.That(actualTL, Is.EqualTo(expectedTL));

            driver.FindElement(By.TagName("h3")).SendKeys(Keys.Enter);

            driver.Close();
            driver.Quit();

        }
    }
}