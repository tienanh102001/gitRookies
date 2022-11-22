using NUnit.Framework;
using testFramework.PageObject;
using testFramework.TestSetup;

namespace testFramework.Testcases
{
    [TestFixture]
    public class TestScenario1 : ProjectNUnitTestSetup
    {
        [Test]
        public void Scenario_1() 
        {
            HomePage homePage = new HomePage(_driver);
            homePage.SelectElement();
            homePage.CheckDisplayElement();
            homePage.SelectWebTable();
            homePage.CheckDisplayWebTable();
        }
          

    }
}
