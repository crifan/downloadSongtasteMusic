using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using downloadSongtasteMusic.Properties;
using System.IO;
//using System.IO.Path;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Threading;

namespace downloadSongtasteMusic
{
    public partial class frmDownloadSongtasteMusic : Form
    {

        public enum downloadMode_t
        {
            INVALID,
            PLAYING, // playing
            SINGLEURL, // single url
        };

        songtaste st;

        public downloadMode_t downloadMode;
        private string curFullFilename;
        public completeHint hintWindow;
        private System.Windows.Forms.Timer closeWindowTimer;
        private System.Windows.Forms.Timer downloadTimer;
        

        //KeyboardHook hook = new KeyboardHook();
        
        public frmDownloadSongtasteMusic()
        {
            InitializeComponent();

            st = new songtaste();
        }
        
        public void showTip(string tipContent)
        {
            int tipShowMilliseconds = 1500;
            string tipTitle = "提示";
            //string tipContent = "你所要显示的内容";
            ToolTipIcon tipType = ToolTipIcon.Info;
            nfiSystem.ShowBalloonTip(tipShowMilliseconds, tipTitle, tipContent, tipType);
        }

        //public void preDownloadTip(string stUrl, string filename, string dirToSave)
        public void preDownloadTip(string stUrl)
        {
            string preDownTip = "开始下载Songtaste歌曲：" + Environment.NewLine + stUrl;
            //preDownTip += Environment.NewLine + "另存为:" + Environment.NewLine + filename;
            //preDownTip += Environment.NewLine + "到:" + Environment.NewLine + dirToSave;
            showTip(preDownTip);
        }

        public void postDownloadTip(string filename, string dirToSave)
        {
            string afterDownTip = "已将歌曲：";
            afterDownTip += Environment.NewLine + filename;
            afterDownTip += Environment.NewLine + "下载保存至：";
            afterDownTip += Environment.NewLine + dirToSave;
            showTip(afterDownTip);
        }

        //method 1: use timer
        private void increaseDownloadProgressBar(object sender, EventArgs e)
        {
            // Increment the value of the ProgressBar a value of one each time.
            int currentPecent = getDownloadPercent();

            //pgbDownload.Increment(1);
            //pgbDownload.Increment(currentPecent);
            pgbDownload.Value = currentPecent;
            
            // Determine if we have completed
            if (pgbDownload.Value >= pgbDownload.Maximum)
            {
                // Stop the timer.
                downloadTimer.Stop();

                pgbDownload.Value = 0;
            }
        }

        // Call this method from the constructor of the form.
        private void initializeDownloadTimer()
        {
            downloadTimer = new System.Windows.Forms.Timer();
            //downloadTimer.Enabled = true;
            // Set the interval for the timer.
            downloadTimer.Interval = 100;
            // Connect the Tick event of the timer to its event handler.
            downloadTimer.Tick += new EventHandler(increaseDownloadProgressBar);
            // Start the timer.
            downloadTimer.Start();
        }

        private void stopTimerClearProgress()
        {
            downloadTimer.Stop();

            pgbDownload.Value = 0;
            //pgbDownload.Update();
            //pgbDownload.Refresh();
            // must add this, otherwise the UI not update !!!
            System.Windows.Forms.Application.DoEvents(); 
        }

        ////method 2: use another thread
        //private delegate void ProgressBarShow(int i);
        //private void ShowPro(int currentProgress)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.Invoke(new ProgressBarShow(ShowPro), currentProgress);
        //    }
        //    else
        //    {
        //        this.pgbDownload.Value = currentProgress;
        //    }
        //}

        //private void updateProgress()
        //{
        //    int currentPecent = 0;
        //    while (currentPecent < 100)
        //    {
        //        currentPecent = getDownloadPercent();
        //        ShowPro(currentPecent);
        //        Thread.Sleep(100);
        //    }

        //    Thread.CurrentThread.Abort();
        //}

        //private void initForDownloadProcess()
        //{
        //    Thread thread = new Thread(new ThreadStart(updateProgress)); //模拟进度条
        //    thread.IsBackground = true;
        //    thread.Start();
        //}

        public int getDownloadPercent()
        {
            return st.getDownloadPercent();
        }

        //stUrl: http://www.songtaste.com/song/955407/
        //dirToSave: D:\download\360se\www.songtaste.com
        public bool downloadSingleStMusic(string idOrUrl, string dirToSave)
        {
            bool downloadOk = false;
            songtaste.songInfo songInfo;
            string errStr = "";
            int maxTryNum = 3;
            int curTryNum = 0;

            while (curTryNum < maxTryNum)
            {
                if (st.getSongInfo(idOrUrl, out songInfo, out errStr))
                {
                    //showTip("现在开始下载地址为：" + Environment.NewLine + stUrl + "的Songtaste歌曲");

                    //preDownloadTip(songInfo.url, songInfo.storedName, txbSaveTo.Text);
                    preDownloadTip(songInfo.url);

                    //string fullnameToStore = dirToSave + "\\" + songInfo.storedName;

                    curFullFilename = Path.Combine(dirToSave, songInfo.storedName);

                    initializeDownloadTimer();
                    //initForDownloadProcess();

                    if (st.downloadStMusicFile(songInfo.realAddr, curFullFilename, out errStr))
                    {
                        postDownloadTip(songInfo.storedName, txbSaveTo.Text);
                        downloadOk = true;
                    }
                    else
                    {
                        showTip("下载Songtaste歌曲：" + songInfo.url + " 失败！错误信息为：" + errStr);
                    }

                    break;
                }

                curTryNum++;
            }

            if (!downloadOk)
            {
                showTip("无法从Songtaste歌曲 " + idOrUrl + " 中获得歌曲的相关信息！错误信息为：" + errStr);
            }

            stopTimerClearProgress();

            return downloadOk;
        }

        public void resetHintWindow()
        {
            if (hintWindow != null)
            {
                //NOTE: here also will call completeHint_FormClosed !!!
                hintWindow.Close();
            }

            hintWindow = null;
        }

        public void closeHintWindow(object sender, EventArgs e)
        {
            closeWindowTimer.Stop();

            resetHintWindow();
        }

        public void showCompleteHint()
        {
            //open hint window
            if (hintWindow == null)
            {
                hintWindow = new completeHint();
            }
            hintWindow.Owner = this;
            hintWindow.initParameter(curFullFilename, txbSaveTo.Text);
            hintWindow.Show();

            //add timer to close window after several seconds
            closeWindowTimer = new System.Windows.Forms.Timer();
            closeWindowTimer.Interval = 5000;
            closeWindowTimer.Tick += new EventHandler(closeHintWindow);
            closeWindowTimer.Start();
        }


        public void downloadPlayingStMusic()
        {
            songtaste st = new songtaste();
            string curSongId = "";

            //find current playing st music
            if (st.getCurPlayingSongId(out curSongId))
            {
                showTip("当前正在播放的Songtaste歌曲的Id为：" + Environment.NewLine + curSongId);
                
                if(downloadSingleStMusic(curSongId, txbSaveTo.Text))
                {
                    showCompleteHint();
                }
            }
            else
            {
                showTip("找不到当前正在播放的Songtaste歌曲！");
            }
        }

        public void downloadStMusicFromUrl()
        {
            string singleStUrl = "";

            //get st url
            singleStUrl = txbStUrl.Text;

            //download it
            if (downloadSingleStMusic(singleStUrl, txbSaveTo.Text))
            {
                showCompleteHint();
            }
        }

        public void showAlbumCompleteHint()
        {
            //open hint window
            if (hintWindow == null)
            {
                hintWindow = new completeHint();
            }
            hintWindow.Owner = this;
            hintWindow.initParameter(txbSaveTo.Text);
            hintWindow.Show();

            //add timer to close window after several seconds
            closeWindowTimer = new System.Windows.Forms.Timer();
            closeWindowTimer.Interval = 5000;
            closeWindowTimer.Tick += new EventHandler(closeHintWindow);
            closeWindowTimer.Start();
        }

        public void downloadStAlbum()
        {
            string origDestFolder = txbSaveTo.Text;
            //example:
            //http://www.songtaste.com/album/320027 has 248 songs
            //http://www.songtaste.com/album/570665 has 6 songs

            List<string> songIdList = st.extractSongIdList(txbAlbumAddr.Text);
            songtaste.albumInfo albumInfo = st.extractAlbumInfo(txbAlbumAddr.Text);
            string albumDirName = albumInfo.name + " - " + albumInfo.author;
            string fullAlbumDirPath = Path.Combine(origDestFolder, albumDirName);
            if (!Directory.Exists(fullAlbumDirPath))
            {
                Directory.CreateDirectory(fullAlbumDirPath);
            }
            txbSaveTo.Text = fullAlbumDirPath;

            //download all
            foreach (string songId in songIdList)
            {
                downloadSingleStMusic(songId, txbSaveTo.Text);
            }

            showAlbumCompleteHint();

            txbSaveTo.Text = origDestFolder;
        }

        public void doDownload()
        {
            //find current download type

            if (tctDownloadType.SelectedTab == tpgPlaying)
            {
                downloadPlayingStMusic();
            }
            else if (tctDownloadType.SelectedTab == tpgSingle)
            {
                downloadStMusicFromUrl();
            }
            else if (tctDownloadType.SelectedTab == tpgAlbum)
            {
                downloadStAlbum();
            }
            else
            {
                showTip("未知下载类型！");
            }
        }

        private void loadSetting()
        {
            //ckbCtrl.Checked = true;
            //ckbAlt.Checked = true;
            //ckbShift.Checked = true;
            //cmbKeys.SelectedItem = "M";

            ckbCtrl.Checked = Settings.Default.ctrl;
            ckbAlt.Checked = Settings.Default.atl;
            ckbShift.Checked = Settings.Default.shift;
            cmbKeys.SelectedItem = Settings.Default.key.ToString();

            txbSaveTo.Text = Settings.Default.saveFolder;
        }

        private void saveHotkey()
        {
            Settings.Default.ctrl = ckbCtrl.Checked;
            Settings.Default.atl = ckbAlt.Checked;
            Settings.Default.shift = ckbShift.Checked;
            Settings.Default.key = Convert.ToChar(cmbKeys.SelectedItem);
            Settings.Default.Save();
        }

        private void saveSelectedFoler()
        {
            Settings.Default.saveFolder = txbSaveTo.Text;
            Settings.Default.Save();
        }

        private void saveAllSetting()
        {
            saveHotkey();
            saveSelectedFoler();
        }

        private void validateSaveFolder()
        {
            //post check settings
            if (!(Directory.Exists(txbSaveTo.Text)))
            {
                //txbSaveTo.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic);
                txbSaveTo.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            }
        }

        private string getCurVerStr()
        {
            string curVerStr = "";
            Assembly asm = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);
            curVerStr = String.Format("{0}.{1}", fvi.ProductMajorPart, fvi.ProductMinorPart);
            return curVerStr;
        }

        private void frmDownloadSonstasteMusic_Load(object sender, EventArgs e)
        {
            hintWindow = null;

            //update version string
            this.Text += " v" + getCurVerStr();

            downloadMode = downloadMode_t.PLAYING;
            if (downloadMode == downloadMode_t.PLAYING)
            {
                tctDownloadType.SelectTab(tpgPlaying);
            }
            else if (downloadMode == downloadMode_t.SINGLEURL)
            {
                tctDownloadType.SelectTab(tpgPlaying);
            }

            loadSetting();

            validateSaveFolder();
        }

        private void frmDownloadSonstasteMusic_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                nfiSystem.Visible = true;
            }
        }

        private void restoreMainWindow()
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.nfiSystem.Visible = false;
        }

        private void nfiSystem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            restoreMainWindow();
        }

        public delegate  void funcDelegate(object sender, KeyPressedEventArgs e);

        public bool registerHotkey(ModifierKeys_e controlKeys, Keys key, funcDelegate func)
        {
            bool registerOk = false;

            KeyboardHook hook = new KeyboardHook();

            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(func);

            try
            {
                hook.RegisterHotKey(controlKeys, key);
                registerOk = true;
            }
            catch (Exception ex)
            {
                registerOk = false;
                MessageBox.Show(ex.Message);
            }

            return registerOk;
        }

        private void btnRegHotkey_Click(object sender, EventArgs e)
        {
            ModifierKeys_e controlKeys = ModifierKeys_e.None;
            Keys key;

            if (ckbCtrl.Checked)
            {
                controlKeys |= ModifierKeys_e.Control;
            }
            if (ckbShift.Checked)
            {
                controlKeys |= ModifierKeys_e.Shift;
            }
            if (ckbAlt.Checked)
            {
                controlKeys |= ModifierKeys_e.Alt;
            }

            Object selectedKey = cmbKeys.Text;
            char keyLetter = Convert.ToChar(selectedKey); //char 'M'
            //key = VkKeyScan(keyLetter); //0x0000014d
            //key = (Keys)selectedKey; // can not work
            key = (Keys)keyLetter; // can work -> convert char 'M' to Keys.M

            if (registerHotkey(controlKeys, key, hook_KeyPressed))
            {
                saveHotkey();
                showTip("快捷键注册成功.");
            }
        }

        private void btnChooseFoler_Click(object sender, EventArgs e)
        {
            fbdSaveTo.SelectedPath = txbSaveTo.Text;
            if (fbdSaveTo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txbSaveTo.Text = fbdSaveTo.SelectedPath; 
            }
        }

        private void frmDownloadSonstasteMusic_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveSelectedFoler();
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (txbSaveTo.Text == "")
            {
                showTip("请设置正确的保存地址！");
                return;
            }

            string hotKey = "";

            hotKey += ((e.Modifier & ModifierKeys_e.Control) == ModifierKeys_e.Control) ? "Ctrl+" : "";
            hotKey += ((e.Modifier & ModifierKeys_e.Alt) == ModifierKeys_e.Alt) ? "Alt+" : "";
            hotKey += ((e.Modifier & ModifierKeys_e.Shift) == ModifierKeys_e.Shift) ? "Shift+" : "";
            hotKey += e.Key.ToString();

            //showTip("已捕获所设置的快捷键：" + e.Modifier.ToString() + " + " + e.Key.ToString());
            showTip("已捕获所设置的快捷键：" + hotKey);

            doDownload();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            doDownload();
        }

        private void 显示主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restoreMainWindow();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lklUsage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string softUsage = "http://www.crifan.com/crifan_released_all/website/dotnet/downloadsongtastemusic/";
            System.Diagnostics.Process.Start(softUsage);
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txbSaveTo.Text);
        }
    }
}
