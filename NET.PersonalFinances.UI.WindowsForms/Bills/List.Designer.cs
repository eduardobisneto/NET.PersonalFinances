namespace NET.PersonalFinances.UI.WindowsForms.Bills
{
    partial class frmListBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsvBills = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lsvBills
            // 
            this.lsvBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvBills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader5});
            this.lsvBills.FullRowSelect = true;
            this.lsvBills.GridLines = true;
            this.lsvBills.Location = new System.Drawing.Point(12, 12);
            this.lsvBills.Name = "lsvBills";
            this.lsvBills.Size = new System.Drawing.Size(749, 376);
            this.lsvBills.TabIndex = 1;
            this.lsvBills.UseCompatibleStateImageBehavior = false;
            this.lsvBills.View = System.Windows.Forms.View.Details;
            this.lsvBills.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsvBills_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "DESCRIPTION";
            this.columnHeader1.Width = 169;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ACCOUNT";
            this.columnHeader2.Width = 105;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "AMOUNT";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 77;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 4;
            this.columnHeader5.Text = "NOTE";
            this.columnHeader5.Width = 303;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 3;
            this.columnHeader3.Text = "DUE DATE";
            this.columnHeader3.Width = 106;
            // 
            // frmListBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(773, 400);
            this.ControlBox = false;
            this.Controls.Add(this.lsvBills);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListBill";
            this.Load += new System.EventHandler(this.frmListBill_Load);
            this.SizeChanged += new System.EventHandler(this.frmListBill_SizeChanged);
            this.Leave += new System.EventHandler(this.frmListBill_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvBills;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}