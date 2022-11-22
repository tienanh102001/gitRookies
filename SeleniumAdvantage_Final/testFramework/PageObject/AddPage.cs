using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testFramework.PageObject
{
    public class AddPage : WebDriverAction
    {
        public AddPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly string Element = "//*[@class='card mt-4 top-card'][1]";
        private readonly string WebTable = "//*[@id='item-3']";
        private readonly string AddButton = "//*[@id='addNewRecordButton']";
        private readonly string SubmitButton = "//*[@id='submit']";
        private readonly string expectScreenElement = "https://demoqa.com/elements";
        private readonly string expectScreenWebTable = "https://demoqa.com/webtables";
        private readonly string firstname = "Tien";
        private readonly string lastname="Anh";
        private readonly string email = "Tienanh@gmail.com";
        private readonly string age = "23";
        private readonly string salary = "100";
        private readonly string department = "Hanoi";

        private readonly string box_firstname = "//*[@id='firstName']";
        private readonly string box_lastname = "//*[@id='lastName']";
        private readonly string box_email = "//*[@id='userEmail']";
        private readonly string box_age = "//*[@id='age']";
        private readonly string box_salary = "//*[@id='salary']";
        private readonly string box_department = "//*[@id='department']";

        public void SelectElement()
        {
            Click(Element);
        }
        public void SelectWebTable()
        {
            Click(WebTable);
        }
        public void ClickSubmit()
        {
            Click(SubmitButton);
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
        public void EnterValidData()
        {
            SendKeys_(box_firstname, firstname);
            SendKeys_(box_lastname, lastname);
            SendKeys_(box_email, email);
            SendKeys_(box_age, age);
            SendKeys_(box_salary, salary);
            SendKeys_(box_department, department);
        }
        public void Row()
        {
            RowTable("//*[@class='rt-table']");
        }
    }
}
