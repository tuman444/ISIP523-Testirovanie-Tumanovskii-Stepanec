using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PR6._3.Pages;

namespace UnitTestProject1
{
    [TestClass]
    public class AuthTestsSucces
    {
        [TestMethod]
        public void AuthTest()
        {
            var page = new LoginPage();
            Assert.IsTrue(page.Auth("user1", "12345"));
            Assert.IsTrue(page.Auth("1111", "1111"));
            Assert.IsTrue(page.Auth("Илья", "123456"));
            Assert.IsTrue(page.Auth("1234", "4321"));
        }
    }
}
