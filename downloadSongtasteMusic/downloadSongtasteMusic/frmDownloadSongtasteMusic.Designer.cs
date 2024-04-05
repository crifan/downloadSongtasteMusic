namespace downloadSongtasteMusic
{
    partial class frmDownloadSongtasteMusic
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadSongtasteMusic));
            this.nfiSystem = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsSystemTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示主界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpTrigHotkey = new System.Windows.Forms.GroupBox();
            this.btnRegHotkey = new System.Windows.Forms.Button();
            this.cmbKeys = new System.Windows.Forms.ComboBox();
            this.ckbShift = new System.Windows.Forms.CheckBox();
            this.ckbAlt = new System.Windows.Forms.CheckBox();
            this.ckbCtrl = new System.Windows.Forms.CheckBox();
            this.txbSaveTo = new System.Windows.Forms.TextBox();
            this.lblSaveTo = new System.Windows.Forms.Label();
            this.btnChooseFoler = new System.Windows.Forms.Button();
            this.fbdSaveTo = new System.Windows.Forms.FolderBrowserDialog();
            this.grbDownloadType = new System.Windows.Forms.GroupBox();
            this.tctDownloadType = new System.Windows.Forms.TabControl();
            this.tpgPlaying = new System.Windows.Forms.TabPage();
            this.tpgSingle = new System.Windows.Forms.TabPage();
            this.txbStUrl = new System.Windows.Forms.TextBox();
            this.lblStUrl = new System.Windows.Forms.Label();
            this.tpgAlbum = new System.Windows.Forms.TabPage();
            this.txbAlbumAddr = new System.Windows.Forms.TextBox();
            this.lblAlbumAddr = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.grbTrigger = new System.Windows.Forms.GroupBox();
            this.grbTrigBtn = new System.Windows.Forms.GroupBox();
            this.grbSave = new System.Windows.Forms.GroupBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.lklUsage = new System.Windows.Forms.LinkLabel();
            this.pgbDownload = new System.Windows.Forms.ProgressBar();
            this.cmsSystemTray.SuspendLayout();
            this.grpTrigHotkey.SuspendLayout();
            this.grbDownloadType.SuspendLayout();
            this.tctDownloadType.SuspendLayout();
            this.tpgSingle.SuspendLayout();
            this.tpgAlbum.SuspendLayout();
            this.grbTrigger.SuspendLayout();
            this.grbTrigBtn.SuspendLayout();
            this.grbSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // nfiSystem
            // 
            this.nfiSystem.ContextMenuStrip = this.cmsSystemTray;
            this.nfiSystem.Icon = ((System.Drawing.Icon)(resources.GetObject("nfiSystem.Icon")));
            this.nfiSystem.Text = "下载Songtaste歌曲";
            this.nfiSystem.Visible = true;
            this.nfiSystem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfiSystem_MouseDoubleClick);
            // 
            // cmsSystemTray
            // 
            this.cmsSystemTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示主界面ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.cmsSystemTray.Name = "cmsSystemTray";
            this.cmsSystemTray.Size = new System.Drawing.Size(137, 48);
            // 
            // 显示主界面ToolStripMenuItem
            // 
            this.显示主界面ToolStripMenuItem.Name = "显示主界面ToolStripMenuItem";
            this.显示主界面ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.显示主界面ToolStripMenuItem.Text = "显示主界面";
            this.显示主界面ToolStripMenuItem.Click += new System.EventHandler(this.显示主界面ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // grpTrigHotkey
            // 
            this.grpTrigHotkey.Controls.Add(this.btnRegHotkey);
            this.grpTrigHotkey.Controls.Add(this.cmbKeys);
            this.grpTrigHotkey.Controls.Add(this.ckbShift);
            this.grpTrigHotkey.Controls.Add(this.ckbAlt);
            this.grpTrigHotkey.Controls.Add(this.ckbCtrl);
            this.grpTrigHotkey.Location = new System.Drawing.Point(37, 20);
            this.grpTrigHotkey.Name = "grpTrigHotkey";
            this.grpTrigHotkey.Size = new System.Drawing.Size(221, 89);
            this.grpTrigHotkey.TabIndex = 0;
            this.grpTrigHotkey.TabStop = false;
            this.grpTrigHotkey.Text = "快捷键";
            // 
            // btnRegHotkey
            // 
            this.btnRegHotkey.Location = new System.Drawing.Point(34, 46);
            this.btnRegHotkey.Name = "btnRegHotkey";
            this.btnRegHotkey.Size = new System.Drawing.Size(164, 28);
            this.btnRegHotkey.TabIndex = 3;
            this.btnRegHotkey.Text = "注册快捷键";
            this.btnRegHotkey.UseVisualStyleBackColor = true;
            this.btnRegHotkey.Click += new System.EventHandler(this.btnRegHotkey_Click);
            // 
            // cmbKeys
            // 
            this.cmbKeys.FormattingEnabled = true;
            this.cmbKeys.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cmbKeys.Location = new System.Drawing.Point(158, 18);
            this.cmbKeys.Name = "cmbKeys";
            this.cmbKeys.Size = new System.Drawing.Size(54, 21);
            this.cmbKeys.TabIndex = 2;
            // 
            // ckbShift
            // 
            this.ckbShift.AutoSize = true;
            this.ckbShift.Checked = true;
            this.ckbShift.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShift.Location = new System.Drawing.Point(105, 20);
            this.ckbShift.Name = "ckbShift";
            this.ckbShift.Size = new System.Drawing.Size(47, 17);
            this.ckbShift.TabIndex = 0;
            this.ckbShift.Text = "Shift";
            this.ckbShift.UseVisualStyleBackColor = true;
            // 
            // ckbAlt
            // 
            this.ckbAlt.AutoSize = true;
            this.ckbAlt.Checked = true;
            this.ckbAlt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAlt.Location = new System.Drawing.Point(61, 20);
            this.ckbAlt.Name = "ckbAlt";
            this.ckbAlt.Size = new System.Drawing.Size(38, 17);
            this.ckbAlt.TabIndex = 0;
            this.ckbAlt.Text = "Alt";
            this.ckbAlt.UseVisualStyleBackColor = true;
            // 
            // ckbCtrl
            // 
            this.ckbCtrl.AutoSize = true;
            this.ckbCtrl.Checked = true;
            this.ckbCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCtrl.Location = new System.Drawing.Point(14, 20);
            this.ckbCtrl.Name = "ckbCtrl";
            this.ckbCtrl.Size = new System.Drawing.Size(41, 17);
            this.ckbCtrl.TabIndex = 0;
            this.ckbCtrl.Text = "Ctrl";
            this.ckbCtrl.UseVisualStyleBackColor = true;
            // 
            // txbSaveTo
            // 
            this.txbSaveTo.Location = new System.Drawing.Point(67, 28);
            this.txbSaveTo.Name = "txbSaveTo";
            this.txbSaveTo.Size = new System.Drawing.Size(255, 20);
            this.txbSaveTo.TabIndex = 2;
            // 
            // lblSaveTo
            // 
            this.lblSaveTo.AutoSize = true;
            this.lblSaveTo.Location = new System.Drawing.Point(7, 27);
            this.lblSaveTo.Name = "lblSaveTo";
            this.lblSaveTo.Size = new System.Drawing.Size(55, 13);
            this.lblSaveTo.TabIndex = 3;
            this.lblSaveTo.Text = "保存至：";
            // 
            // btnChooseFoler
            // 
            this.btnChooseFoler.Location = new System.Drawing.Point(328, 27);
            this.btnChooseFoler.Name = "btnChooseFoler";
            this.btnChooseFoler.Size = new System.Drawing.Size(55, 21);
            this.btnChooseFoler.TabIndex = 4;
            this.btnChooseFoler.Text = "浏览";
            this.btnChooseFoler.UseVisualStyleBackColor = true;
            this.btnChooseFoler.Click += new System.EventHandler(this.btnChooseFoler_Click);
            // 
            // grbDownloadType
            // 
            this.grbDownloadType.Controls.Add(this.tctDownloadType);
            this.grbDownloadType.Location = new System.Drawing.Point(12, 7);
            this.grbDownloadType.Name = "grbDownloadType";
            this.grbDownloadType.Size = new System.Drawing.Size(448, 147);
            this.grbDownloadType.TabIndex = 5;
            this.grbDownloadType.TabStop = false;
            this.grbDownloadType.Text = "下载类型";
            // 
            // tctDownloadType
            // 
            this.tctDownloadType.Controls.Add(this.tpgPlaying);
            this.tctDownloadType.Controls.Add(this.tpgSingle);
            this.tctDownloadType.Controls.Add(this.tpgAlbum);
            this.tctDownloadType.Location = new System.Drawing.Point(7, 20);
            this.tctDownloadType.Name = "tctDownloadType";
            this.tctDownloadType.SelectedIndex = 0;
            this.tctDownloadType.Size = new System.Drawing.Size(435, 121);
            this.tctDownloadType.TabIndex = 0;
            // 
            // tpgPlaying
            // 
            this.tpgPlaying.Location = new System.Drawing.Point(4, 22);
            this.tpgPlaying.Name = "tpgPlaying";
            this.tpgPlaying.Padding = new System.Windows.Forms.Padding(3);
            this.tpgPlaying.Size = new System.Drawing.Size(427, 95);
            this.tpgPlaying.TabIndex = 0;
            this.tpgPlaying.Text = "正在播放";
            this.tpgPlaying.UseVisualStyleBackColor = true;
            // 
            // tpgSingle
            // 
            this.tpgSingle.Controls.Add(this.txbStUrl);
            this.tpgSingle.Controls.Add(this.lblStUrl);
            this.tpgSingle.Location = new System.Drawing.Point(4, 22);
            this.tpgSingle.Name = "tpgSingle";
            this.tpgSingle.Padding = new System.Windows.Forms.Padding(3);
            this.tpgSingle.Size = new System.Drawing.Size(427, 95);
            this.tpgSingle.TabIndex = 1;
            this.tpgSingle.Text = "单首ST歌曲";
            this.tpgSingle.UseVisualStyleBackColor = true;
            // 
            // txbStUrl
            // 
            this.txbStUrl.Location = new System.Drawing.Point(131, 33);
            this.txbStUrl.Name = "txbStUrl";
            this.txbStUrl.Size = new System.Drawing.Size(272, 20);
            this.txbStUrl.TabIndex = 1;
            this.txbStUrl.Text = "http://www.songtaste.com/song/3208674/";
            // 
            // lblStUrl
            // 
            this.lblStUrl.AutoSize = true;
            this.lblStUrl.Location = new System.Drawing.Point(53, 36);
            this.lblStUrl.Name = "lblStUrl";
            this.lblStUrl.Size = new System.Drawing.Size(72, 13);
            this.lblStUrl.TabIndex = 0;
            this.lblStUrl.Text = "ST歌曲地址:";
            // 
            // tpgAlbum
            // 
            this.tpgAlbum.Controls.Add(this.txbAlbumAddr);
            this.tpgAlbum.Controls.Add(this.lblAlbumAddr);
            this.tpgAlbum.Location = new System.Drawing.Point(4, 22);
            this.tpgAlbum.Name = "tpgAlbum";
            this.tpgAlbum.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAlbum.Size = new System.Drawing.Size(427, 95);
            this.tpgAlbum.TabIndex = 2;
            this.tpgAlbum.Text = "整张ST专辑";
            this.tpgAlbum.UseVisualStyleBackColor = true;
            // 
            // txbAlbumAddr
            // 
            this.txbAlbumAddr.Location = new System.Drawing.Point(131, 33);
            this.txbAlbumAddr.Name = "txbAlbumAddr";
            this.txbAlbumAddr.Size = new System.Drawing.Size(272, 20);
            this.txbAlbumAddr.TabIndex = 3;
            this.txbAlbumAddr.Text = "http://www.songtaste.com/album/597900";
            // 
            // lblAlbumAddr
            // 
            this.lblAlbumAddr.AutoSize = true;
            this.lblAlbumAddr.Location = new System.Drawing.Point(18, 36);
            this.lblAlbumAddr.Name = "lblAlbumAddr";
            this.lblAlbumAddr.Size = new System.Drawing.Size(107, 13);
            this.lblAlbumAddr.TabIndex = 2;
            this.lblAlbumAddr.Text = "ST专辑(Album)地址:";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(19, 20);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(86, 53);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // grbTrigger
            // 
            this.grbTrigger.Controls.Add(this.grbTrigBtn);
            this.grbTrigger.Controls.Add(this.grpTrigHotkey);
            this.grbTrigger.Location = new System.Drawing.Point(12, 231);
            this.grbTrigger.Name = "grbTrigger";
            this.grbTrigger.Size = new System.Drawing.Size(448, 121);
            this.grbTrigger.TabIndex = 7;
            this.grbTrigger.TabStop = false;
            this.grbTrigger.Text = "下载触发类型";
            // 
            // grbTrigBtn
            // 
            this.grbTrigBtn.Controls.Add(this.btnDownload);
            this.grbTrigBtn.Location = new System.Drawing.Point(292, 20);
            this.grbTrigBtn.Name = "grbTrigBtn";
            this.grbTrigBtn.Size = new System.Drawing.Size(122, 89);
            this.grbTrigBtn.TabIndex = 7;
            this.grbTrigBtn.TabStop = false;
            this.grbTrigBtn.Text = "按钮";
            // 
            // grbSave
            // 
            this.grbSave.Controls.Add(this.btnOpenFolder);
            this.grbSave.Controls.Add(this.lblSaveTo);
            this.grbSave.Controls.Add(this.txbSaveTo);
            this.grbSave.Controls.Add(this.btnChooseFoler);
            this.grbSave.Location = new System.Drawing.Point(12, 160);
            this.grbSave.Name = "grbSave";
            this.grbSave.Size = new System.Drawing.Size(448, 64);
            this.grbSave.TabIndex = 8;
            this.grbSave.TabStop = false;
            this.grbSave.Text = "保存";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(387, 27);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(55, 21);
            this.btnOpenFolder.TabIndex = 5;
            this.btnOpenFolder.Text = "打开";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // lklUsage
            // 
            this.lklUsage.AutoSize = true;
            this.lklUsage.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lklUsage.Location = new System.Drawing.Point(121, 392);
            this.lklUsage.Name = "lklUsage";
            this.lklUsage.Size = new System.Drawing.Size(236, 19);
            this.lklUsage.TabIndex = 9;
            this.lklUsage.TabStop = true;
            this.lklUsage.Text = "downloadSongtasteMusic 使用说明";
            this.lklUsage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklUsage_LinkClicked);
            // 
            // pgbDownload
            // 
            this.pgbDownload.BackColor = System.Drawing.SystemColors.Control;
            this.pgbDownload.Location = new System.Drawing.Point(12, 359);
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.Size = new System.Drawing.Size(448, 25);
            this.pgbDownload.Step = 1;
            this.pgbDownload.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbDownload.TabIndex = 10;
            // 
            // frmDownloadSongtasteMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 423);
            this.Controls.Add(this.grbDownloadType);
            this.Controls.Add(this.pgbDownload);
            this.Controls.Add(this.grbSave);
            this.Controls.Add(this.lklUsage);
            this.Controls.Add(this.grbTrigger);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDownloadSongtasteMusic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "downloadSongtasteMusic - 下载Songtaste歌曲";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDownloadSonstasteMusic_FormClosed);
            this.Load += new System.EventHandler(this.frmDownloadSonstasteMusic_Load);
            this.SizeChanged += new System.EventHandler(this.frmDownloadSonstasteMusic_SizeChanged);
            this.cmsSystemTray.ResumeLayout(false);
            this.grpTrigHotkey.ResumeLayout(false);
            this.grpTrigHotkey.PerformLayout();
            this.grbDownloadType.ResumeLayout(false);
            this.tctDownloadType.ResumeLayout(false);
            this.tpgSingle.ResumeLayout(false);
            this.tpgSingle.PerformLayout();
            this.tpgAlbum.ResumeLayout(false);
            this.tpgAlbum.PerformLayout();
            this.grbTrigger.ResumeLayout(false);
            this.grbTrigBtn.ResumeLayout(false);
            this.grbSave.ResumeLayout(false);
            this.grbSave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nfiSystem;
        private System.Windows.Forms.GroupBox grpTrigHotkey;
        private System.Windows.Forms.CheckBox ckbShift;
        private System.Windows.Forms.CheckBox ckbAlt;
        private System.Windows.Forms.CheckBox ckbCtrl;
        private System.Windows.Forms.ComboBox cmbKeys;
        private System.Windows.Forms.Button btnRegHotkey;
        private System.Windows.Forms.TextBox txbSaveTo;
        private System.Windows.Forms.Label lblSaveTo;
        private System.Windows.Forms.Button btnChooseFoler;
        private System.Windows.Forms.FolderBrowserDialog fbdSaveTo;
        private System.Windows.Forms.GroupBox grbDownloadType;
        private System.Windows.Forms.TabControl tctDownloadType;
        private System.Windows.Forms.TabPage tpgPlaying;
        private System.Windows.Forms.TabPage tpgSingle;
        private System.Windows.Forms.Label lblStUrl;
        private System.Windows.Forms.TextBox txbStUrl;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.GroupBox grbTrigger;
        private System.Windows.Forms.GroupBox grbTrigBtn;
        private System.Windows.Forms.GroupBox grbSave;
        private System.Windows.Forms.ContextMenuStrip cmsSystemTray;
        private System.Windows.Forms.ToolStripMenuItem 显示主界面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.TabPage tpgAlbum;
        private System.Windows.Forms.TextBox txbAlbumAddr;
        private System.Windows.Forms.Label lblAlbumAddr;
        private System.Windows.Forms.LinkLabel lklUsage;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ProgressBar pgbDownload;
    }
}

