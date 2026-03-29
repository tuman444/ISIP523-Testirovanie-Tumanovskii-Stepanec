using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6._3.Pages;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class RegTestFail
    {
        [TestMethod]
        public void RegisterTestFail()
        {
            var page = new RegisterPage();

            Assert.IsFalse(page.Register("", "", "", "", ""));

            Assert.IsFalse(page.Register("Иван", "Иванов", "userX", "123", "321"));

            Assert.IsFalse(page.Register("Иван", "Иванов", "user1", "123", "123"));
        }
    }
}
