using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;

namespace testFramework.PageObject
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver? driver) : base(driver)
        {
        }

        private readonly string Element = "//*[@class='card mt-4 top-card'][1]";
        private readonly string WebTable = "//*[@id='item-3']";
        private readonly string AddButton = "//*[@id='addNewRecordButton']";
        private readonly string expectScreenElement = "https://demoqa.com/elements";
        private readonly string expectScreenWebTable = "https://demoqa.com/webtables";
        public void SelectElement()
        {
            Click(Element);
        }
        public void SelectWebTable()
        {
            Click(WebTable);
        }
        public void CheckDisplayElement()
        {
            CompareUrl(expectScreenElement);            
        }
        public void CheckDisplayWebTable()
        {
            CompareUrl(expectScreenWebTable);
        }
        public void GoToAddScreen()
        {
            Click(AddButton);
        }
    }

}