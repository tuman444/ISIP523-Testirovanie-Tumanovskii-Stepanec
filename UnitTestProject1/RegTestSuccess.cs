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
                "Алексей",
                "Алексеевич",
                "new_user_222",
                "5555",
                "5555"
            );

            Assert.IsTrue(result);
        }
    }
}
