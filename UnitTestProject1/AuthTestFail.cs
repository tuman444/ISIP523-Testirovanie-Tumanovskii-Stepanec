using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6._3.Pages;
namespace UnitTestProject1
{
    [TestClass]
    public class AuthTestFail
    {
        [TestMethod]
        public void AuthTest_Fail()
        {
            var page = new LoginPage { IsTest = true };
            Assert.IsFalse(page.Auth("", ""));
            Assert.IsFalse(page.Auth(" ", " "));
            Assert.IsFalse(page.Auth("user1", "wrong"));
            Assert.IsFalse(page.Auth("not_exist", "123"));
        }
    }
}
