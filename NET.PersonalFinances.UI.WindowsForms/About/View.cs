using System;
using System.Windows.Forms;

namespace NET.PersonalFinances.UI.WindowsForms.About
{
    public partial class frmViewAbout : Form
    {
        public frmViewAbout()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            try
            {
                lblAbout.Text = System.Configuration.ConfigurationManager.AppSettings["About"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {

        }
    }
}
