namespace AdbTools
{
    partial class frmLogcat
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbProcess = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.llblClear = new System.Windows.Forms.LinkLabel();
            this.llblExport = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLogs);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 614);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志";
            // 
            // txtLogs
            // 
            this.txtLogs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLogs.Location = new System.Drawing.Point(18, 20);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(740, 588);
            this.txtLogs.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbLevel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.cmbProcess);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "筛选";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSearch.Location = new System.Drawing.Point(455, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 26);
            this.txtSearch.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(407, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "搜索";
            // 
            // cmbLevel
            // 
            this.cmbLevel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Location = new System.Drawing.Point(323, 23);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(76, 24);
            this.cmbLevel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(282, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "级别";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 12F);
            this.btnStart.Location = new System.Drawing.Point(648, 23);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 25);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbProcess
            // 
            this.cmbProcess.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbProcess.FormattingEnabled = true;
            this.cmbProcess.Location = new System.Drawing.Point(55, 22);
            this.cmbProcess.Name = "cmbProcess";
            this.cmbProcess.Size = new System.Drawing.Size(216, 24);
            this.cmbProcess.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "进程";
            // 
            // llblClear
            // 
            this.llblClear.AutoSize = true;
            this.llblClear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llblClear.Location = new System.Drawing.Point(28, 700);
            this.llblClear.Name = "llblClear";
            this.llblClear.Size = new System.Drawing.Size(35, 14);
            this.llblClear.TabIndex = 2;
            this.llblClear.TabStop = true;
            this.llblClear.Text = "清空";
            this.llblClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblClear_LinkClicked);
            // 
            // llblExport
            // 
            this.llblExport.AutoSize = true;
            this.llblExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llblExport.Location = new System.Drawing.Point(735, 700);
            this.llblExport.Name = "llblExport";
            this.llblExport.Size = new System.Drawing.Size(35, 14);
            this.llblExport.TabIndex = 3;
            this.llblExport.TabStop = true;
            this.llblExport.Text = "导出";
            this.llblExport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblExport_LinkClicked);
            // 
            // frmLogcat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 719);
            this.Controls.Add(this.llblExport);
            this.Controls.Add(this.llblClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogcat";
            this.Text = "Logcat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogcat_FormClosed);
            this.Load += new System.EventHandler(this.frmLogcat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProcess;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.LinkLabel llblClear;
        private System.Windows.Forms.LinkLabel llblExport;
    }
}