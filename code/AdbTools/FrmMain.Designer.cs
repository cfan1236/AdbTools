namespace AdbTools
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAdbDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblTips = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ltPicLog = new System.Windows.Forms.ListBox();
            this.lblPsTips = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnFilePath = new System.Windows.Forms.Button();
            this.btnPrintScreen = new System.Windows.Forms.Button();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.cmsPicCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblApkTips = new System.Windows.Forms.Label();
            this.lblApkFile = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnLogcat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.cmsPicCopy.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAdbDir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblIp);
            this.groupBox1.Controls.Add(this.lblTips);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Location = new System.Drawing.Point(24, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接";
            // 
            // txtAdbDir
            // 
            this.txtAdbDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdbDir.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAdbDir.Location = new System.Drawing.Point(71, 23);
            this.txtAdbDir.Name = "txtAdbDir";
            this.txtAdbDir.ReadOnly = true;
            this.txtAdbDir.Size = new System.Drawing.Size(232, 26);
            this.txtAdbDir.TabIndex = 5;
            this.txtAdbDir.Click += new System.EventHandler(this.txtAdbDir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "ADB目录";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIp.Location = new System.Drawing.Point(317, 26);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(24, 16);
            this.lblIp.TabIndex = 3;
            this.lblIp.Text = "IP";
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTips.Location = new System.Drawing.Point(629, 28);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(35, 14);
            this.lblTips.TabIndex = 2;
            this.lblTips.Text = "****";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.Location = new System.Drawing.Point(526, 22);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(82, 25);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtIp
            // 
            this.txtIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIp.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIp.Location = new System.Drawing.Point(351, 20);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(160, 29);
            this.txtIp.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ltPicLog);
            this.groupBox2.Controls.Add(this.lblPsTips);
            this.groupBox2.Controls.Add(this.lblFilePath);
            this.groupBox2.Controls.Add(this.btnFilePath);
            this.groupBox2.Controls.Add(this.btnPrintScreen);
            this.groupBox2.Controls.Add(this.picImg);
            this.groupBox2.Location = new System.Drawing.Point(24, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(746, 405);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "截图";
            // 
            // ltPicLog
            // 
            this.ltPicLog.AllowDrop = true;
            this.ltPicLog.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ltPicLog.FormattingEnabled = true;
            this.ltPicLog.ItemHeight = 14;
            this.ltPicLog.Location = new System.Drawing.Point(424, 103);
            this.ltPicLog.Name = "ltPicLog";
            this.ltPicLog.Size = new System.Drawing.Size(268, 284);
            this.ltPicLog.TabIndex = 6;
            this.ltPicLog.SelectedIndexChanged += new System.EventHandler(this.ltPicLog_SelectedIndexChanged);
            // 
            // lblPsTips
            // 
            this.lblPsTips.AutoSize = true;
            this.lblPsTips.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPsTips.Location = new System.Drawing.Point(519, 72);
            this.lblPsTips.Name = "lblPsTips";
            this.lblPsTips.Size = new System.Drawing.Size(35, 14);
            this.lblPsTips.TabIndex = 5;
            this.lblPsTips.Text = "****";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFilePath.Location = new System.Drawing.Point(519, 29);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(40, 16);
            this.lblFilePath.TabIndex = 3;
            this.lblFilePath.Text = "****";
            // 
            // btnFilePath
            // 
            this.btnFilePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFilePath.Location = new System.Drawing.Point(423, 24);
            this.btnFilePath.Name = "btnFilePath";
            this.btnFilePath.Size = new System.Drawing.Size(75, 25);
            this.btnFilePath.TabIndex = 2;
            this.btnFilePath.Text = "保存路径";
            this.btnFilePath.UseVisualStyleBackColor = true;
            this.btnFilePath.Click += new System.EventHandler(this.btnFilePath_Click);
            // 
            // btnPrintScreen
            // 
            this.btnPrintScreen.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrintScreen.Location = new System.Drawing.Point(424, 64);
            this.btnPrintScreen.Name = "btnPrintScreen";
            this.btnPrintScreen.Size = new System.Drawing.Size(75, 25);
            this.btnPrintScreen.TabIndex = 2;
            this.btnPrintScreen.Text = "截图";
            this.btnPrintScreen.UseVisualStyleBackColor = true;
            this.btnPrintScreen.Click += new System.EventHandler(this.btnPrintScreen_Click);
            // 
            // picImg
            // 
            this.picImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImg.ContextMenuStrip = this.cmsPicCopy;
            this.picImg.Location = new System.Drawing.Point(10, 23);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(397, 365);
            this.picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImg.TabIndex = 0;
            this.picImg.TabStop = false;
            // 
            // cmsPicCopy
            // 
            this.cmsPicCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuCopy});
            this.cmsPicCopy.Name = "cmsPicCopy";
            this.cmsPicCopy.Size = new System.Drawing.Size(101, 26);
            // 
            // toolMenuCopy
            // 
            this.toolMenuCopy.Name = "toolMenuCopy";
            this.toolMenuCopy.Size = new System.Drawing.Size(100, 22);
            this.toolMenuCopy.Text = "复制";
            this.toolMenuCopy.Click += new System.EventHandler(this.toolMenuCopy_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblApkTips);
            this.groupBox3.Controls.Add(this.lblApkFile);
            this.groupBox3.Controls.Add(this.btnInstall);
            this.groupBox3.Location = new System.Drawing.Point(24, 497);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(746, 122);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "软件安装";
            // 
            // lblApkTips
            // 
            this.lblApkTips.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApkTips.ForeColor = System.Drawing.Color.Red;
            this.lblApkTips.Location = new System.Drawing.Point(418, 62);
            this.lblApkTips.Name = "lblApkTips";
            this.lblApkTips.Size = new System.Drawing.Size(322, 22);
            this.lblApkTips.TabIndex = 6;
            this.lblApkTips.Text = "****";
            this.lblApkTips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApkFile
            // 
            this.lblApkFile.AllowDrop = true;
            this.lblApkFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblApkFile.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApkFile.Location = new System.Drawing.Point(10, 17);
            this.lblApkFile.Name = "lblApkFile";
            this.lblApkFile.Size = new System.Drawing.Size(397, 93);
            this.lblApkFile.TabIndex = 0;
            this.lblApkFile.Text = "将要安装的APK拖拽到此处";
            this.lblApkFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblApkFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblApkFile_DragDrop);
            this.lblApkFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblApkFile_DragEnter);
            // 
            // btnInstall
            // 
            this.btnInstall.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInstall.Location = new System.Drawing.Point(544, 20);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 25);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "安装APK";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnLogcat
            // 
            this.btnLogcat.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogcat.Location = new System.Drawing.Point(24, 622);
            this.btnLogcat.Name = "btnLogcat";
            this.btnLogcat.Size = new System.Drawing.Size(75, 25);
            this.btnLogcat.TabIndex = 3;
            this.btnLogcat.Text = "logcat";
            this.btnLogcat.UseVisualStyleBackColor = true;
            this.btnLogcat.Click += new System.EventHandler(this.btnLogcat_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 653);
            this.Controls.Add(this.btnLogcat);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "AdbTools";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.cmsPicCopy.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.Button btnPrintScreen;
        private System.Windows.Forms.Button btnFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblPsTips;
        private System.Windows.Forms.ListBox ltPicLog;
        private System.Windows.Forms.ContextMenuStrip cmsPicCopy;
        private System.Windows.Forms.ToolStripMenuItem toolMenuCopy;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblApkFile;
        private System.Windows.Forms.Label lblApkTips;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdbDir;
        private System.Windows.Forms.Button btnLogcat;
    }
}

