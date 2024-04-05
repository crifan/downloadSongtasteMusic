using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace downloadSongtasteMusic
{
    public partial class completeHint : Form
    {
        private string curFullFilename;
        private string curFolderPath;
        private bool onlyShowFoler;
        private frmDownloadSongtasteMusic curParentForm;
        private crifanLib crl;

        public completeHint()
        {
            InitializeComponent();

            curParentForm = null;
            crl = new crifanLib();

            onlyShowFoler = false;
        }

        //for single music complete, show open file and folder
        public void initParameter(string fullFilename, string folderPath)
        {
            curFullFilename = fullFilename;
            curFolderPath = folderPath;

            curParentForm = (frmDownloadSongtasteMusic)this.Owner;

            onlyShowFoler = false;
        }

        //for album complete, only show open folder
        public void initParameter(string folderPath)
        {
            curFolderPath = folderPath;

            lklOpenFile.Hide();
            //calc the new pos for folder label
            int newX = this.Width / 2 - lklOpenFolder.Size.Width/2;
            lklOpenFolder.Location = new Point(newX, lklOpenFolder.Location.Y);

            curParentForm = (frmDownloadSongtasteMusic)this.Owner;

            onlyShowFoler = true;
        }

        private void lklOpenFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //open file
            System.Diagnostics.Process.Start(curFullFilename);
        }

        private void lklOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //open folder and select file
            if (onlyShowFoler)
            {
                System.Diagnostics.Process.Start(curFolderPath);
            }
            else
            {
                System.Diagnostics.Process.Start("Explorer.exe", "/select," + curFullFilename); // Note: only 2 para !!!
            }
        }

        private void completeHint_Load(object sender, EventArgs e)
        {
            //Size curTaskbarSize = crl.getCurTaskbarSize();
            //Point curTaskbarLocation = crl.getCurTaskbarLocation();
            this.Location = crl.getCornerLocation(this.Size);
        }

        private void completeHint_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (curParentForm != null)
            {
                //!!! should NOT call resetHintWindow here, otherwise will dead loop
                curParentForm.hintWindow = null;
            }
        }
    }
}
