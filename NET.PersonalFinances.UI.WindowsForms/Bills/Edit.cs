using NET.PersonalFinances.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NET.PersonalFinances.UI.WindowsForms.Bills
{
    public partial class frmEditBill : Form
    {
        public Entity.Enum.AccountNature accountNatureId;

        public frmEditBill()
        {
            InitializeComponent();
        }

        public frmEditBill(Entity.Enum.AccountNature AccountNatureId, string Title) : this()
        {
            accountNatureId = AccountNatureId;
            this.Text = Title;
        }

        private void Edit_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                Fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Repeat();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Clear()
        {
            txtAmount.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtNote.Text = string.Empty;
            cmbAcount.SelectedIndex = -1;
            nudRepeat.Value = 0;
            dtpDueDate.Value = DateTime.Now;
        }

        void Fill()
        {
            FillAccounts();
            FillRepeatFrequency();
        }

        void FillRepeatFrequency()
        {
            cmbFrequency.DataSource = new[] {
                new { Text = "Peer Month".ToUpper(), Value = "0" },
                new { Text = "Peer Week".ToUpper(), Value = "1" }
            };
            cmbFrequency.DisplayMember = "Text";
            cmbFrequency.ValueMember = "Value";
            cmbFrequency.SelectedIndex = 0;
        }

        void FillAccounts()
        {
            IEnumerable<Account> list = Program.billAccounts.Where(
                a => a.AccountNatureId == (int)this.accountNatureId
                && a.AccountTypeId == (int)Entity.Enum.AccountType.Analytic).ToList();

            cmbAcount.DataSource = list;
            cmbAcount.DisplayMember = "Description";
            cmbAcount.ValueMember = "Id";
            cmbAcount.SelectedIndex = -1;
        }

        void InsertRange(IEnumerable<AccountMovement> accountMovements)
        {
            var req = new Util.Request<IEnumerable<AccountMovement>, IEnumerable<AccountMovement>>();
            req.Post("api/bill/insertRangeAccountMovement", accountMovements).Wait();

            if (!req.IsSuccess)
                MessageBox.Show(req.ResponseMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void Repeat()
        {
            List<AccountMovement> accountMovements = new List<AccountMovement>();

            for (var i = 0; i <= nudRepeat.Value; i++)
            {
                accountMovements.Add(new AccountMovement()
                {
                    Note = txtNote.Text.Trim(),
                    DueDate = (cmbFrequency.SelectedIndex == 0 ? dtpDueDate.Value.AddMonths(i) : dtpDueDate.Value.AddDays((i > 0 ? (7 * i) : 0))),
                    Description = txtDescription.Text.Trim(),
                    Amount = (txtAmount.Text.Trim().Length > 0 ? Convert.ToDecimal(txtAmount.Text.Trim()) : 0),
                    OperationTypeId = (int)Entity.Enum.OperationType.Credit,
                    AccountId = (cmbAcount.SelectedIndex >= 0 ? Convert.ToInt32(cmbAcount.SelectedValue) : 0)
                });
            }

            InsertRange(accountMovements);
        }
    }
}
