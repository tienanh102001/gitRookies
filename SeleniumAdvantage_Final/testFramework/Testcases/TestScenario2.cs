using NUnit.Framework;
using testFramework.PageObject;
using testFramework.TestSetup;

namespace testFramework.Testcases
{
    [TestFixture]
    public class TestScenario2 : ProjectNUnitTestSetup
    {
        [Test]
        public void TestAuto() 
        {
            AddPage AddPage = new AddPage(_driver);
            AddPage.SelectElement();
            AddPage.CheckDisplayElement();
            AddPage.SelectWebTable();
            AddPage.CheckDisplayWebTable();
            AddPage.GoToAddScreen();
            AddPage.EnterValidData();
            AddPage.ClickSubmit();
        }  

    }
}
