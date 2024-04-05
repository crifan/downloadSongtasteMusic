namespace downloadSongtasteMusic
{
    partial class completeHint
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
            this.lklOpenFile = new System.Windows.Forms.LinkLabel();
            this.lklOpenFolder = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lklOpenFile
            // 
            this.lklOpenFile.AutoSize = true;
            this.lklOpenFile.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklOpenFile.Location = new System.Drawing.Point(34, 22);
            this.lklOpenFile.Name = "lklOpenFile";
            this.lklOpenFile.Size = new System.Drawing.Size(74, 22);
            this.lklOpenFile.TabIndex = 0;
            this.lklOpenFile.TabStop = true;
            this.lklOpenFile.Text = "打开文件";
            this.lklOpenFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklOpenFile_LinkClicked);
            // 
            // lklOpenFolder
            // 
            this.lklOpenFolder.AutoSize = true;
            this.lklOpenFolder.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.lklOpenFolder.Location = new System.Drawing.Point(130, 22);
            this.lklOpenFolder.Name = "lklOpenFolder";
            this.lklOpenFolder.Size = new System.Drawing.Size(74, 22);
            this.lklOpenFolder.TabIndex = 1;
            this.lklOpenFolder.TabStop = true;
            this.lklOpenFolder.Text = "打开目录";
            this.lklOpenFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklOpenFolder_LinkClicked);
            // 
            // completeHint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 70);
            this.Controls.Add(this.lklOpenFolder);
            this.Controls.Add(this.lklOpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "completeHint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "文件下载完毕提醒";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.completeHint_FormClosed);
            this.Load += new System.EventHandler(this.completeHint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lklOpenFile;
        private System.Windows.Forms.LinkLabel lklOpenFolder;

    }
}