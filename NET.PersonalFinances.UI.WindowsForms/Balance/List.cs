using NET.PersonalFinances.Entity;
using NET.PersonalFinances.UI.WindowsForms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace NET.PersonalFinances.UI.WindowsForms.Balance
{
    public partial class frmListBalance : Form
    {
        public frmListBalance()
        {
            InitializeComponent();
        }

        #region : Events

        private void frmListBalance_Leave(object sender, EventArgs e)
        {
            //Program.frmListBalance = null;
        }

        private void frmListBalance_SizeChanged(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Previous();
        }

        private void cmbPeriodicity_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void frmListBalance_Load(object sender, EventArgs e)
        {
            try
            {
                GetAll();
                FillPeriodicity();
                Fill();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                switch (Program.periodicity)
                {
                    case Model.Enum.Periodicity.PeerDay:
                        Program.dateBalanceStart = dtpPeriod.Value;
                        Program.dateBalanceEnd = Program.dateBalanceStart;
                        break;
                    case Model.Enum.Periodicity.PeerWeek:
                        Program.sunday = dtpPeriod.Value.GetSundayBefore();
                        Program.dateBalanceStart = Program.sunday;
                        Program.dateBalanceEnd = Program.sunday.AddDays(7);
                        break;
                    case Model.Enum.Periodicity.PeerMonth:
                        Program.dateBalanceStart = new DateTime(dtpPeriod.Value.Year, 1, 1);
                        Program.dateBalanceEnd = Program.dateBalanceStart.AddYears(1).AddDays(-1);
                        break;
                    case Model.Enum.Periodicity.PeerYear:

                        break;
                }

                UpdatePeriod();
                FillColumns();
                FillAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.frmListBalance = null;
            Close();
        }

        private void cmbPeriodicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPeriodicity.SelectedValue is System.Int32)
                {
                    Program.periodicity = (Model.Enum.Periodicity)(int)cmbPeriodicity.SelectedValue;

                    switch (Program.periodicity)
                    {
                        case Model.Enum.Periodicity.PeerDay:
                            Program.dateBalanceStart = dtpPeriod.Value;
                            Program.dateBalanceEnd = Program.dateBalanceStart;
                            break;
                        case Model.Enum.Periodicity.PeerWeek:
                            Program.sunday = dtpPeriod.Value.GetSundayBefore();
                            Program.dateBalanceStart = Program.sunday;
                            Program.dateBalanceEnd = Program.sunday.AddDays(7);
                            break;
                        case Model.Enum.Periodicity.PeerMonth:
                            Program.dateBalanceStart = new DateTime(dtpPeriod.Value.Year, 1, 1);
                            Program.dateBalanceEnd = Program.dateBalanceStart.AddYears(1).AddDays(-1);
                            break;
                        case Model.Enum.Periodicity.PeerYear:
                            break;
                    }

                    UpdatePeriod();
                    FillColumns();
                    FillAccounts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHoje_Click(object sender, EventArgs e)
        {
            Today();
        }

        #endregion

        #region : Methods

        public void GetAll()
        {
            var req = new Util.Request<Entity.Filter.Balance, IEnumerable<Entity.Balance>>();

            req.Post("api/bill/getBalance", new Entity.Filter.Balance()
            {
                Start = Program.dateBalanceStart,
                End = Program.dateBalanceEnd
            }).Wait();

            if (req.IsSuccess)
                Program.billBalance = req.ResponseObject;
            else
                MessageBox.Show(req.ResponseMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Fill()
        {
            UpdatePeriod();
            FillColumns();
            FillAccounts();
        }

        void FillPeriodicity()
        {
            cmbPeriodicity.DataSource = new[] {
                new { Text = "Peer Day".ToUpper(), Value = 0 },
                new { Text = "Peer Week".ToUpper(), Value = 1 },
                new { Text = "Peer Month".ToUpper(), Value = 2 },
                new { Text = "Peer Year".ToUpper(), Value = 3 }
            };
            cmbPeriodicity.DisplayMember = "Text";
            cmbPeriodicity.ValueMember = "Value";
            cmbPeriodicity.SelectedIndex = 2;
        }

        void FillAccounts(Account account)
        {
            IEnumerable<Account> list = Program.billAccounts.Where(
                a => a.AccountId == (null == account ? 0 : account.Id)).ToList();

            foreach (Account a in list)
            {
                string[] balance = Balance(a);
                balance[0] = a.Description.ToUpper();

                lsvBalance.Items.Add(
                    new ListViewItem(balance)
                    {
                        Font = new System.Drawing.Font(lsvBalance.Font, (a.AccountTypeId == (int)Entity.Enum.AccountType.Sintetic ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular)),
                        BackColor = (a.AccountTypeId == (int)Entity.Enum.AccountType.Sintetic ? System.Drawing.Color.FromArgb(235, 235, 235) : System.Drawing.Color.FromArgb(255, 255, 255))
                    }
                );
                FillAccounts(a);
            }
        }

        void FillAccounts()
        {
            lsvBalance.Items.Clear();

            IEnumerable<Account> list = Program.billAccounts.Where(
                a => a.AccountId == null).ToList();

            foreach (Account a in list)
            {
                string[] balance = Balance(a);
                balance[0] = a.Description.ToUpper();

                lsvBalance.Items.Add(
                    new ListViewItem(balance)
                    {
                        Font = new System.Drawing.Font(lsvBalance.Font, (a.AccountTypeId == (int)Entity.Enum.AccountType.Sintetic ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular)),
                        BackColor = (a.AccountTypeId == (int)Entity.Enum.AccountType.Sintetic ? System.Drawing.Color.FromArgb(200, 200, 200) : System.Drawing.Color.FromArgb(255, 255, 255))
                    }
                );
                FillAccounts(a);
            }
        }

        decimal? GetSinteticBalance(Account account, DateTime period, decimal? amount)
        {
            decimal? sinteticAmount = amount;
            decimal? total = 0;

            IEnumerable<Account> list = Program.billAccounts.Where(
                a => a.AccountId == account.Id);

            foreach (Account a in list)
            {
                switch (Program.periodicity)
                {
                    case Model.Enum.Periodicity.PeerMonth:
                        total = Program.billBalance.Where(
                            ma => ma.Id == a.Id
                            && (null != ma.DueDate ? ma.DueDate.Value.Month == period.Month && ma.DueDate.Value.Year == period.Year : ma.DueDate == null)).Sum(am => am.Amount);
                        break;
                    case Model.Enum.Periodicity.PeerWeek:
                        total = Program.billBalance.Where(
                            ma => ma.Id == a.Id
                            && (null != ma.DueDate ? ma.DueDate.Value.Day == period.Day && ma.DueDate.Value.Month == period.Month && ma.DueDate.Value.Year == period.Year : ma.DueDate == null)).Sum(am => am.Amount);
                        break;
                }

                sinteticAmount = GetSinteticBalance(a, period, total + sinteticAmount);
            }

            return sinteticAmount;
        }

        decimal? GetSinteticBalance(Account account, DateTime period)
        {
            decimal? amount = 0;

            IEnumerable<Account> list = Program.billAccounts.Where(
                a => a.Id == account.Id);

            foreach (Account a in list)
            {
                switch (Program.periodicity)
                {
                    case Model.Enum.Periodicity.PeerMonth:
                        amount = Program.billBalance.Where(
                            ma => ma.Id == a.Id
                            && (null != ma.DueDate ? ma.DueDate.Value.Month == period.Month && ma.DueDate.Value.Year == period.Year : ma.DueDate == null)).Sum(am => am.Amount);
                        break;
                    case Model.Enum.Periodicity.PeerWeek:
                        amount = Program.billBalance.Where(
                            ma => ma.Id == a.Id
                            && (null != ma.DueDate ? ma.DueDate.Value.Day == period.Day && ma.DueDate.Value.Month == period.Month && ma.DueDate.Value.Year == period.Year : ma.DueDate == null)).Sum(am => am.Amount);
                        break;
                    default:
                        amount = 0;
                        break;
                }

                amount += GetSinteticBalance(a, period, amount);
            }

            return amount;
        }

        decimal? Balance(Account account, DateTime period)
        {
            switch (Program.periodicity)
            {
                case Model.Enum.Periodicity.PeerMonth:
                    switch (account.AccountTypeId)
                    {
                        case (int)Entity.Enum.AccountType.Analytic:
                            return Program.billBalance.Where(
                                    a => a.Id == account.Id
                                    && (null != a.DueDate ? a.DueDate.Value.Month == period.Month && a.DueDate.Value.Year == period.Year : a.DueDate == null)).Sum(a => a.Amount);
                        case (int)Entity.Enum.AccountType.Sintetic:
                            return GetSinteticBalance(account, period);
                        default:
                            return 0;
                    }
                case Model.Enum.Periodicity.PeerWeek:
                    switch (account.AccountTypeId)
                    {
                        case (int)Entity.Enum.AccountType.Analytic:
                            return Program.billBalance.Where(
                            a => a.Id == account.Id
                            && (null != a.DueDate ? a.DueDate.Value.Day == period.Day && a.DueDate.Value.Month == period.Month && a.DueDate.Value.Year == period.Year : a.DueDate == null)).Sum(a => a.Amount);
                        case (int)Entity.Enum.AccountType.Sintetic:
                            return GetSinteticBalance(account, period);
                        default:
                            return 0;
                    }
                default:
                    return 0;
            }
        }

        string[] Balance(Account account)
        {
            string[] balance;

            switch (Program.periodicity)
            {
                case Model.Enum.Periodicity.PeerMonth:
                    balance = new string[13];

                    for (int x = 0; x < 12; x++)
                    {
                        DateTime mes = Program.dateBalanceStart.AddMonths(x);
                        decimal? amount = Balance(account, mes);
                        balance.SetValue(amount.Value.ToString("n2"), x + 1);
                    }
                    return balance;
                case Model.Enum.Periodicity.PeerWeek:
                    balance = new string[8];

                    for (int x = 0; x < 7; x++)
                    {
                        DateTime dia = Program.dateBalanceStart.AddDays(x);
                        decimal? amount = Balance(account, dia);
                        balance.SetValue(amount.Value.ToString("n2"), x + 1);
                    }
                    return balance;
                default:
                    return new string[1];
            }
        }

        void FillColumns()
        {
            lsvBalance.Columns.Clear();
            lsvBalance.Columns.Add(new ColumnHeader()
            {
                Text = "Description",
                Width = 200
            });

            switch (Program.periodicity)
            {
                case Model.Enum.Periodicity.PeerDay: //Peer Day
                    lsvBalance.Columns.Add(new ColumnHeader() { Text = dtpPeriod.Value.ToShortDateString(), Width = 250 });
                    break;
                case Model.Enum.Periodicity.PeerWeek: //Peer Week
                    foreach (string week in DateTimeFormatInfo.CurrentInfo.AbbreviatedDayNames)
                        lsvBalance.Columns.Add(new ColumnHeader() { Text = week.ToUpper(), Width = 85 });
                    break;
                case Model.Enum.Periodicity.PeerMonth: //Peer Month
                    foreach (string week in DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames)
                        lsvBalance.Columns.Add(new ColumnHeader() { Text = week.ToUpper(), Width = 65 });
                    break;
                case Model.Enum.Periodicity.PeerYear: //Peer Year
                    break;
            }
        }

        void Next()
        {
            switch (Program.periodicity)
            {
                case Model.Enum.Periodicity.PeerDay:
                    Program.dateBalanceStart = Program.dateBalanceEnd;
                    Program.dateBalanceEnd = Program.dateBalanceEnd.AddDays(1);
                    dtpPeriod.Value = Program.dateBalanceStart;
                    break;
                case Model.Enum.Periodicity.PeerWeek:
                    Program.dateBalanceStart = Program.dateBalanceEnd;
                    Program.dateBalanceEnd = Program.dateBalanceEnd.AddDays(7);
                    dtpPeriod.Value = Program.dateBalanceStart;
                    break;
                case Model.Enum.Periodicity.PeerMonth:
                    dtpPeriod.Value = dtpPeriod.Value.AddMonths(1);
                    Program.dateBalanceStart = new DateTime(dtpPeriod.Value.Year, 1, 1);
                    Program.dateBalanceEnd = Program.dateBalanceStart.AddYears(1).AddDays(-1);
                    break;
                case Model.Enum.Periodicity.PeerYear:
                    break;
            }

            //dtpPeriod.Value = Program.dateBalanceStart;

            //UpdatePeriod();
            //FillColumns();
            //FillAccounts();
        }

        void Previous()
        {
            switch (Program.periodicity)
            {
                case Model.Enum.Periodicity.PeerDay:
                    Program.dateBalanceStart = Program.dateBalanceEnd;
                    Program.dateBalanceEnd = Program.dateBalanceEnd.AddDays(-1);
                    dtpPeriod.Value = Program.dateBalanceStart;
                    break;
                case Model.Enum.Periodicity.PeerWeek:
                    Program.dateBalanceEnd = Program.dateBalanceStart;
                    Program.dateBalanceStart = Program.dateBalanceEnd.AddDays(-7);
                    dtpPeriod.Value = Program.dateBalanceStart;
                    break;
                case Model.Enum.Periodicity.PeerMonth:
                    dtpPeriod.Value = new DateTime(dtpPeriod.Value.Year, dtpPeriod.Value.Month, 1).AddMonths(-1);
                    Program.dateBalanceStart = new DateTime(dtpPeriod.Value.Year, 1, 1);
                    Program.dateBalanceEnd = Program.dateBalanceStart.AddYears(1).AddDays(-1);
                    break;
                case Model.Enum.Periodicity.PeerYear:
                    break;
            }

            //dtpPeriod.Value = Program.dateBalanceStart;

            //UpdatePeriod();
            //FillColumns();
            //FillAccounts();
        }

        void Today()
        {
            switch (Program.periodicity)
            {
                case Model.Enum.Periodicity.PeerDay:
                    Program.dateBalanceStart = DateTime.Now;
                    Program.dateBalanceEnd = Program.dateBalanceStart;
                    break;
                case Model.Enum.Periodicity.PeerWeek:
                    Program.sunday = DateTime.Now.GetSundayBefore();
                    Program.dateBalanceStart = Program.sunday;
                    Program.dateBalanceEnd = Program.sunday.AddDays(7);
                    break;
                case Model.Enum.Periodicity.PeerMonth:
                    Program.dateBalanceStart = new DateTime(DateTime.Now.Year, 1, 1);
                    Program.dateBalanceEnd = Program.dateBalanceStart.AddYears(1).AddDays(-1);
                    break;
                case Model.Enum.Periodicity.PeerYear:
                    //Program.dateBalanceEnd = Program.dateBalanceEnd.AddYears(-1);
                    break;
            }

            dtpPeriod.Value = DateTime.Now;
        }

        void UpdatePeriod()
        {
            tslPeriodo.Text = string.Format("Period: {0} - {1}", Program.dateBalanceStart.ToShortDateString(), Program.dateBalanceEnd.ToShortDateString());
            tslPeriodicity.Text = string.Format("Periodicity: {0}", cmbPeriodicity.Text);
        }

        #endregion
    }
}
