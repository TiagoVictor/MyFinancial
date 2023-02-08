using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFinancial.Service;

namespace MyFinancialTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            UserService userService = new UserService();

            var teste = await userService.GetAllUsersAsync();
            Assert.AreEqual(1, 1);
        }
    }
}
