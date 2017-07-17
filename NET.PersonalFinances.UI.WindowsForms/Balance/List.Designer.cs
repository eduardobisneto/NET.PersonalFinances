namespace NET.PersonalFinances.UI.WindowsForms.Balance
{
    partial class frmListBalance
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
            this.lsvBalance = new System.Windows.Forms.ListView();
            this.cmbPeriodicity = new System.Windows.Forms.ComboBox();
            this.dtpPeriod = new System.Windows.Forms.DateTimePicker();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslPeriodo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslPeriodicity = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnHoje = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvBalance
            // 
            this.lsvBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvBalance.GridLines = true;
            this.lsvBalance.Location = new System.Drawing.Point(12, 41);
            this.lsvBalance.MultiSelect = false;
            this.lsvBalance.Name = "lsvBalance";
            this.lsvBalance.Size = new System.Drawing.Size(755, 338);
            this.lsvBalance.TabIndex = 4;
            this.lsvBalance.UseCompatibleStateImageBehavior = false;
            this.lsvBalance.View = System.Windows.Forms.View.Details;
            // 
            // cmbPeriodicity
            // 
            this.cmbPeriodicity.FormattingEnabled = true;
            this.cmbPeriodicity.Location = new System.Drawing.Point(403, 14);
            this.cmbPeriodicity.Name = "cmbPeriodicity";
            this.cmbPeriodicity.Size = new System.Drawing.Size(103, 21);
            this.cmbPeriodicity.TabIndex = 35;
            this.cmbPeriodicity.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodicity_SelectedIndexChanged);
            this.cmbPeriodicity.SelectedValueChanged += new System.EventHandler(this.cmbPeriodicity_SelectedValueChanged);
            // 
            // dtpPeriod
            // 
            this.dtpPeriod.Location = new System.Drawing.Point(12, 15);
            this.dtpPeriod.Name = "dtpPeriod";
            this.dtpPeriod.Size = new System.Drawing.Size(280, 20);
            this.dtpPeriod.TabIndex = 36;
            this.dtpPeriod.ValueChanged += new System.EventHandler(this.dtpDueDate_ValueChanged);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(352, 12);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(23, 23);
            this.btnPrevious.TabIndex = 37;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(374, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 23);
            this.btnNext.TabIndex = 38;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslPeriodo,
            this.tslPeriodicity});
            this.statusStrip1.Location = new System.Drawing.Point(0, 397);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(779, 22);
            this.statusStrip1.TabIndex = 39;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslPeriodo
            // 
            this.tslPeriodo.Name = "tslPeriodo";
            this.tslPeriodo.Size = new System.Drawing.Size(0, 17);
            // 
            // tslPeriodicity
            // 
            this.tslPeriodicity.Name = "tslPeriodicity";
            this.tslPeriodicity.Size = new System.Drawing.Size(0, 17);
            // 
            // btnHoje
            // 
            this.btnHoje.Location = new System.Drawing.Point(298, 13);
            this.btnHoje.Name = "btnHoje";
            this.btnHoje.Size = new System.Drawing.Size(48, 23);
            this.btnHoje.TabIndex = 40;
            this.btnHoje.Text = "Today";
            this.btnHoje.UseVisualStyleBackColor = true;
            this.btnHoje.Click += new System.EventHandler(this.btnHoje_Click);
            // 
            // frmListBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(779, 419);
            this.ControlBox = false;
            this.Controls.Add(this.btnHoje);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.dtpPeriod);
            this.Controls.Add(this.cmbPeriodicity);
            this.Controls.Add(this.lsvBalance);
            this.Name = "frmListBalance";
            this.Text = "Balance";
            this.Load += new System.EventHandler(this.frmListBalance_Load);
            this.SizeChanged += new System.EventHandler(this.frmListBalance_SizeChanged);
            this.Leave += new System.EventHandler(this.frmListBalance_Leave);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lsvBalance;
        private System.Windows.Forms.ComboBox cmbPeriodicity;
        private System.Windows.Forms.DateTimePicker dtpPeriod;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslPeriodo;
        private System.Windows.Forms.Button btnHoje;
        private System.Windows.Forms.ToolStripStatusLabel tslPeriodicity;
    }
}