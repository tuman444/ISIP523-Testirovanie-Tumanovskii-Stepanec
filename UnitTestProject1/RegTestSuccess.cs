using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6._3.Pages;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class RegTestSuccess
    {
        [TestMethod]
        public void RegisterTestSuccess()
        {
            var page = new RegisterPage();

            bool result = page.Register(
                "12345",
                "54321",
                "55555555",
                "55555555",
                "55555555"
            );

            Assert.IsTrue(result);
        }
    }
}
