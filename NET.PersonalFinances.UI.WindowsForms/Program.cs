using NET.PersonalFinances.Entity;
using NET.PersonalFinances.UI.WindowsForms.Balance;
using NET.PersonalFinances.UI.WindowsForms.Bills;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace NET.PersonalFinances.UI.WindowsForms
{
    static class Program
    {
        public static frmListBalance frmListBalance;
        public static frmListBill frmListBill;
        public static IEnumerable<Account> billAccounts;
        public static IEnumerable<Account> billAllAccounts;
        public static IEnumerable<AccountMovement> billAccountsMovements;
        public static IEnumerable<Entity.Balance> billBalance;
        public static Entity.Enum.AccountNature accountNatureId;
        public static Entity.Enum.AccountNature accountListNatureId;
        public static DateTime dateBalanceStart;
        public static DateTime dateBalanceEnd;
        public static DateTime sunday;
        public static Model.Enum.Periodicity periodicity;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
