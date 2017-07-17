using NET.PersonalFinances.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NET.PersonalFinances.UI.WindowsForms.Bills
{
    public partial class frmListBill : Form
    {
        public frmListBill()
        {
            InitializeComponent();
        }

        public frmListBill(Entity.Enum.AccountNature AccountNatureId, string Title) : this()
        {
            Program.accountListNatureId = AccountNatureId;
            this.Text = Title;
        }

        private void frmListBill_Load(object sender, EventArgs e)
        {
            try
            {
                GetAll();
                Fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmListBill_Leave(object sender, EventArgs e)
        {
            //Program.frmListBill = null;
        }

        public void GetAll()
        {
            var req = new Util.Request<AccountMovement, IEnumerable<AccountMovement>>();

            req.Post("api/bill/getAllAccountsMovements", new AccountMovement()
            {
                Account = new Account()
                {
                    AccountNatureId = (int)Program.accountListNatureId
                }
            }).Wait();

            if (req.IsSuccess)
                Program.billAccountsMovements = req.ResponseObject;
            else
                MessageBox.Show(req.ResponseMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Fill()
        {
            lsvBills.Items.Clear();

            foreach (AccountMovement item in Program.billAccountsMovements)
            {
                lsvBills.Items.Add(new ListViewItem(new string[] {
                    item.Description,
                    item.Account.Description.ToUpper(),
                    item.Amount.ToString("n2"),
                    item.Note,
                    item.DueDate.ToString()
                }));
            }
        }

        private void lsvBills_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(lsvBills.SelectedItems[0].Index.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.frmListBill = null;
            Close();            
        }

        private void frmListBill_SizeChanged(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }
    }
}
