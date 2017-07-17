using NET.PersonalFinances.Entity;
using NET.PersonalFinances.UI.WindowsForms.About;
using NET.PersonalFinances.UI.WindowsForms.Balance;
using NET.PersonalFinances.UI.WindowsForms.Bills;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NET.PersonalFinances.UI.WindowsForms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        #region : Events

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                Program.periodicity = Model.Enum.Periodicity.PeerMonth;
                Program.dateBalanceStart = new DateTime(DateTime.Now.Year, 1, 1);
                Program.dateBalanceEnd = Program.dateBalanceStart.AddYears(1).AddDays(-1);

                GetAllAccounts();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void billsToPayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenBillEdit(Entity.Enum.AccountNature.Passive, "Bill to pay");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenBillEdit(Entity.Enum.AccountNature.Active, "Bill to receive");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void showAllBillsToReceiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenBillList(Entity.Enum.AccountNature.Active, "Bills to receive");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void showAllBillsToPayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenBillList(Entity.Enum.AccountNature.Passive, "Bills to pay");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void balanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenBalanceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Methods

        void OpenBalanceList()
        {
            if (null == Program.frmListBalance)
            {
                frmListBalance frmListBalance = new frmListBalance();
                frmListBalance.MdiParent = this;
                frmListBalance.StartPosition = FormStartPosition.CenterScreen;
                frmListBalance.WindowState = FormWindowState.Maximized;
                frmListBalance.MaximizeBox = false;
                frmListBalance.MinimizeBox = false;
                frmListBalance.Show();

                Program.frmListBalance = frmListBalance;
            }
            else
            {
                Program.frmListBalance.GetAll();
                Program.frmListBalance.Fill();
                Program.frmListBalance.WindowState = FormWindowState.Maximized;
                Program.frmListBalance.Activate();
            }
        }

        void OpenBillList(Entity.Enum.AccountNature AccountNatureId, string Title)
        {
            if (null == Program.frmListBill)
            {
                frmListBill frmListBill = new frmListBill(AccountNatureId, Title);
                frmListBill.MdiParent = this;
                frmListBill.StartPosition = FormStartPosition.CenterScreen;
                frmListBill.WindowState = FormWindowState.Maximized;
                frmListBill.MaximizeBox = false;
                frmListBill.MinimizeBox = false;
                frmListBill.Show();

                Program.frmListBill = frmListBill;
            }
            else
            {

                Program.accountListNatureId = AccountNatureId;
                Program.frmListBill.Text = Title;
                Program.frmListBill.GetAll();
                Program.frmListBill.Fill();
                Program.frmListBill.WindowState = FormWindowState.Maximized;
                Program.frmListBill.Activate();
            }
        }

        void OpenBillEdit(Entity.Enum.AccountNature AccountNatureId, string Title)
        {
            frmEditBill frmEditBill = new frmEditBill(AccountNatureId, Title);
            frmEditBill.StartPosition = FormStartPosition.CenterScreen;
            frmEditBill.ShowDialog();
        }

        void GetAllAccounts()
        {
            var req = new Util.Request<Account, IEnumerable<Account>>();

            req.Post("api/bill/getAllAccounts", new Account()
            {
                //AccountNatureId = (int)this.accountNatureId,
                //AccountTypeId = (int)Entity.Enum.AccountType.Analytic
            }).Wait();

            if (req.IsSuccess)
                Program.billAccounts = req.ResponseObject;
            else
                MessageBox.Show(req.ResponseMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        private void aboutTheDeveloperToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmViewAbout frmViewAbout = new frmViewAbout();
            frmViewAbout.StartPosition = FormStartPosition.CenterScreen;
            frmViewAbout.ShowDialog();
        }
    }
}
