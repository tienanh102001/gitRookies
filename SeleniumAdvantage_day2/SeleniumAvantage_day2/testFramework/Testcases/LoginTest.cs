using NUnit.Framework;
using NUnit.Framework.Internal;
using testFramework.PageObject;
using testFramework.TestSetup;

namespace testFramework.Testcases
{
    [TestFixture]
    public class LoginTest : ProjectNUnitTestSetup
    {
        [Test]
        public void Id1_Login()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.inputUserName("test");
        }
    }
}
