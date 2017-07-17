using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.PersonalFinances.Core;
using System.Collections.Generic;

namespace TestContext
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestAccountsCount()
        {
            Account account = new Account();

            List<Account> accounts = account.GetAll() as List<Account>;

            if (null != accounts)
                Assert.AreNotEqual(0, accounts.Count);
        }
    }
}
