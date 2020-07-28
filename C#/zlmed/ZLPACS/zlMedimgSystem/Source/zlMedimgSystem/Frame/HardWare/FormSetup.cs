///////////////////////////////////////////////////////////////////////////////////////
//
//  TWAINCSScan.FormSetup
//
//  This class helps us configure a TWAIN driver prior to scanning.
//
///////////////////////////////////////////////////////////////////////////////////////
//  Author          Date            Version     Comment
//  M.McLaughlin    21-May-2014     2.0.0.0     64-bit Linux
//  M.McLaughlin    27-Feb-2014     1.1.0.0     ShowImage additions
//  M.McLaughlin    21-Oct-2013     1.0.0.0     Initial Release
///////////////////////////////////////////////////////////////////////////////////////
//  Copyright (C) 2013-2019 Kodak Alaris Inc.
//
//  Permission is hereby granted, free of charge, to any person obtaining a
//  copy of this software and associated documentation files (the "Software"),
//  to deal in the Software without restriction, including without limitation
//  the rights to use, copy, modify, merge, publish, distribute, sublicense,
//  and/or sell copies of the Software, and to permit persons to whom the
//  Software is furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//  FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//  DEALINGS IN THE SOFTWARE.
///////////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Security.Permissions;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TWAINWorkingGroupToolkit; 
using System.Configuration;
using TWAINWorkingGroup;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.HardWare
{
    /// <summary>
    /// Select the image destination folder.  If supported, allow the user to
    /// create and select Custom DS Data snapshots of the driver, and give
    /// them a way to change the driver settings through the setup form of the
    /// driver's user interface...
    /// </summary>
    public partial class FormSetup : Form
    {
        private bool _isLoading = false; 

        ///////////////////////////////////////////////////////////////////////////////
        // Public Methods...
        ///////////////////////////////////////////////////////////////////////////////
        #region Public Methods...

        /// <summary>
        /// Our constructor...
        /// </summary>
        /// <param name="a_twaincstool"></param>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust", Unrestricted = false)]
        public FormSetup(ref TWAINCSToolkit a_twaincstoolkit, string a_szProductDirectory)
        {
            TWAIN.STS sts;
            string szStatus;
            string szCapability;
            string szUsrUiSettings;

            // Init stuff...
            InitializeComponent();
             
            // More init stuff...
            this.FormClosing += new FormClosingEventHandler(FormSetup_FormClosing);

            _isLoading = true;

            // Init more stuff (the order matters).  ApplicationData means the following:
            // Windows:     C:\Users\USERNAME\AppData\Roaming (or C:\Documents and Settings\USERNAME\Application Data on XP)
            // Linux:       /home/USERNAME/.config (or /root/.config for superuser)
            // Mac OS X:    /Users/USERNAME/.config (or /var/root/.config for superuser)
            m_twaincstoolkit = a_twaincstoolkit;
            m_szTwainscanFolder = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"twain"),"twaincsscan");
            m_szSettingsFolder = Path.Combine(m_szTwainscanFolder,"settings");
            m_szSettingsFolder = Path.Combine(m_szSettingsFolder, a_szProductDirectory);
            if (!Directory.Exists(m_szTwainscanFolder))
            {
                try
                {
                    Directory.CreateDirectory(m_szTwainscanFolder);
                }
                catch (Exception exception)
                {
                    TWAINWorkingGroupToolkit.Log.Error("exception - " + exception.Message);
                    m_szTwainscanFolder = System.Windows.Forms.Application.StartupPath;
                }
            }


            // Restore values...
            m_textboxFolder.Text = RestoreFolder();
            m_textboxUseUiSettings.Text = "";

            // Make sure we prime the value...
            m_twaincstoolkit.SetImagePath(m_textboxFolder.Text,0);

            // Check for support of Custom DS Data...
            szStatus = "";
            szCapability = "CAP_CUSTOMDSDATA";
            sts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_GETCURRENT", ref szCapability, ref szStatus);
            if ((sts != TWAIN.STS.SUCCESS) || !szCapability.EndsWith(",1"))
            {
                m_labelUseUiSettings.Enabled = false;
                m_textboxUseUiSettings.Enabled = false;
                m_buttonSaveUiSettings.Enabled = false;
                m_buttonUseUiSettings.Enabled = false;
            }

            // Restore the last saved snapshot...
            else
            {
                m_textboxUseUiSettings.Text = RestoreSetting("settingfile");
                if (m_textboxUseUiSettings.Text != "")
                {
                    szUsrUiSettings = Path.Combine(m_szSettingsFolder, m_textboxUseUiSettings.Text);
                    if (File.Exists(szUsrUiSettings))
                    {
                        m_twaincstoolkit.RestoreSnapshot(szUsrUiSettings);
                    }
                    else
                    {
                        m_textboxUseUiSettings.Text = "";
                    }
                }
            }

            string transferMode = RestoreSetting("transfermode");

            SetTwainTransferMode(transferMode);

            transferMode = GetTwainTransferMode();

            switch (transferMode)
            {
                case "0":
                    rbLocate.Checked = true;
                    break;
                case "1":
                    rbBuffer.Checked = true;
                    break;
                case "2":
                    rbFile.Checked = true;
                    break;
                default:
                    rbLocate.Checked = true;
                    break;
            }

            _isLoading = false;
        }

        /// <summary>
        /// Let the caller know if we can take snapshots...
        /// </summary>
        /// <returns></returns>
        public bool IsCustomDsDataSupported()
        {
            return (m_buttonUseUiSettings.Enabled);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////
        // Private Methods...
        ///////////////////////////////////////////////////////////////////////////////
        #region Private Methods...

        /// <summary>
        /// Validate...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((m_twaincstoolkit.GetImagePath() != "") && !Directory.Exists(m_twaincstoolkit.GetImagePath()))
            {
                MessageBox.Show("Please enter a valid Destination Folder.");
                e.Cancel = true;
            }
            if ((m_textboxUseUiSettings.Text != "") && !File.Exists(Path.Combine(m_szSettingsFolder,m_textboxUseUiSettings.Text)))
            {
                MessageBox.Show("Please enter a valid UI Setting name, or clear the entry.");
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Get the folder path...
        /// </summary>
        /// <returns></returns>
        private string RestoreFolder()
        {
            try
            {
                string szSaveSpot = m_szTwainscanFolder;
                if (!Directory.Exists(szSaveSpot))
                {
                    return ("");
                }
                string szFile = Path.Combine(szSaveSpot, "folder");
                if (File.Exists(szFile))
                {
                    return (File.ReadAllText(szFile));
                }
                return ("");
            }
            catch (Exception exception)
            {
                TWAINWorkingGroupToolkit.Log.Error("exception - " + exception.Message);
                return ("");
            }
        }

        /// <summary>
        /// Get the setting...
        /// </summary>
        /// <returns></returns>
        private string RestoreSetting(string itemName)
        {
            try
            {
                return AppSetting.ReadSetting(itemName);
            }
            catch (Exception exception)
            {
                TWAINWorkingGroupToolkit.Log.Error("exception - " + exception.Message);
                return ("");
            }
        }

        /// <summary>
        /// Remember the folder path for the next time the app runs...
        /// </summary>
        /// <param name="a_szFolder"></param>
        private void SaveFolder(string a_szFolder)
        {
            try
            {
                string szSaveSpot = m_szTwainscanFolder;
                if (!Directory.Exists(szSaveSpot))
                {
                    Directory.CreateDirectory(szSaveSpot);
                }
                File.WriteAllText(Path.Combine(szSaveSpot, "folder"), a_szFolder);
            }
            catch (Exception exception)
            {
                TWAINWorkingGroupToolkit.Log.Error("exception - " + exception.Message);
                // Just let it slide...
            }
        }

        /// <summary>
        /// Remember the setting for the next time the app runs...
        /// </summary>
        /// <param name="a_szFolder"></param>
        private void SaveSetting(string itemName, string value)
        {
            try
            {
                AppSetting.WriteSetting(itemName, value);
            }
            catch (Exception exception)
            {
                TWAINWorkingGroupToolkit.Log.Error("exception - " + exception.Message);
                // Just let it slide...
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////
        // Private Form Controls...
        ///////////////////////////////////////////////////////////////////////////////
        #region Private Form Controls...

        /// <summary>
        /// Browse for a place to save image files...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderbrowserdialog = new FolderBrowserDialog();
            folderbrowserdialog.SelectedPath = m_textboxFolder.Text;
            folderbrowserdialog.ShowNewFolderButton = true;
            if (folderbrowserdialog.ShowDialog(this) == DialogResult.OK)
            {
                m_textboxFolder.Text = folderbrowserdialog.SelectedPath;
                m_twaincstoolkit.SetImagePath(folderbrowserdialog.SelectedPath, 0);
                SaveFolder(m_textboxFolder.Text);
            }
        }

        /// <summary>
        /// Delete the setting...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_buttonDeleteSetting_Click(object sender, EventArgs e)
        {
            bool blDeleted;

            // Nothing to do if it's empty...
            if (m_textboxUseUiSettings.Text == "")
            {
                return;
            }

            // If it's not real, tell the user...
            if (!File.Exists(Path.Combine(m_szSettingsFolder, m_textboxUseUiSettings.Text)))
            {
                MessageBox.Show("'" + m_textboxUseUiSettings.Text + "' not found...");
                return;
            }

            // Get confirmation...
            DialogResult dialogresult = MessageBox.Show("Delete '" + m_textboxUseUiSettings.Text + "'?","Confirm",MessageBoxButtons.YesNo);
            if (dialogresult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            // Delete it...
            try
            {
                blDeleted = true;
                File.Delete(Path.Combine(m_szSettingsFolder, m_textboxUseUiSettings.Text));
            }
            catch (Exception exception)
            {
                TWAINWorkingGroupToolkit.Log.Error("exception - " + exception.Message);
                blDeleted = false;
                //MessageBox.Show("Failed to delete setting...");
                MsgBox.ShowException(exception, "设置删除失败.",this);
            }

            // Clear the text box...
            if (blDeleted)
            {
                m_textboxUseUiSettings.Text = "";
            }
        }

        /// <summary>
        /// Save the current driver's settings...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_buttonSaveas_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.InitialDirectory = m_szSettingsFolder;
            savefiledialog.CheckFileExists = false;
            savefiledialog.CheckPathExists = true;
            savefiledialog.Filter = "Settings|*.settings";
            if (!Directory.Exists(savefiledialog.InitialDirectory))
            {
                try
                {
                    Directory.CreateDirectory(savefiledialog.InitialDirectory);
                }
                catch (Exception exception)
                {
                    TWAINWorkingGroupToolkit.Log.Error("exception - " + exception.Message);
                    MsgBox.ShowException(exception, this);

                    return;
                }
            }
            if (savefiledialog.ShowDialog(this) == DialogResult.OK)
            {
                m_textboxUseUiSettings.Text = Path.GetFileName(savefiledialog.FileName);
                m_twaincstoolkit.SaveSnapshot(Path.Combine(m_szSettingsFolder,m_textboxUseUiSettings.Text));

                SaveSetting("settingfile" , m_textboxUseUiSettings.Text);
            }
        }

        /// <summary>
        /// Bring up the driver's non-scanning UI...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_buttonSetup_Click(object sender, EventArgs e)
        {
            string szTwmemref = "1,0," + Handle;
            string szStatus = "";
            TWAIN.STS sts;
            
            sts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_USERINTERFACE", "MSG_ENABLEDSUIONLY", ref szTwmemref, ref szStatus);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //设置为文件交换模式

            string szTwmemref = "1,0," + Handle;
            string szStatus = "";
            TWAIN.STS sts;

  
            //TWAIN.TW_CAPABILITY twc = default(TWAIN.TW_CAPABILITY);

            //先使用ICAP_XFERMECH读取默认配置
            //twc.Cap = TWAIN.CAP.ICAP_XFERMECH;
            //m_twaincstoolkit.m_twain.DatCapability(TWAIN.DG.CONTROL, TWAIN.MSG.GET, ref twc);


            szTwmemref = "ICAP_COMPRESSION";
            //sts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_GET", ref szTwmemref, ref szStatus);
            //string support = szTwmemref;
            szTwmemref = "";

            sts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_GET", ref szTwmemref, ref szStatus);

            string[] pros = szTwmemref.Split(',');
            pros[3] = "1";


            szTwmemref = String.Join(",", pros); 
            sts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_SET", ref szTwmemref, ref szStatus);

            //szTwmemref = "ICAP_XFERMECH";
            //ts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_GET", ref szTwmemref, ref szStatus);


            //string setting = "";

            //m_twaincstoolkit.m_twain.CsvToCapability(ref twc, ref setting, szTwmemref);

            ////需要先赊账该属性后，才能转换
            //twc.ConType = TWAIN.TWON.ONEVALUE;
            ////twc.Cap = TWAIN.CAP.ICAP_XFERMECH;

            ////string setting = "TWON_ONEVALUE";


            ////转换为对应的字符格式
            //szTwmemref = m_twaincstoolkit.m_twain.CapabilityToCsv(twc);

            ////szTwmemref = "ICAP_XFERMECH";


            ////sts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_GET", ref szTwmemref, ref szStatus);

            ////设置对应的传输模式
            //sts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_SET", ref szTwmemref, ref szStatus);
             
        }

        /// <summary>
        /// Pick the settings for a scan session...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_buttonUseUiSettings_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.InitialDirectory = m_szSettingsFolder;
            openfiledialog.CheckFileExists = true;
            openfiledialog.CheckPathExists = true;
            openfiledialog.Multiselect = false;
            openfiledialog.Filter = "Settings|*.settings";
            openfiledialog.FilterIndex = 0;
            if (!Directory.Exists(openfiledialog.InitialDirectory))
            {
                try
                {
                    Directory.CreateDirectory(openfiledialog.InitialDirectory);
                }
                catch (Exception exception)
                {
                    TWAINWorkingGroupToolkit.Log.Error("exception - " + exception.Message);
                    //MessageBox.Show("Unable to create settings folder...'" + m_szSettingsFolder + "'");
                    MsgBox.ShowException(exception, "不能创建设置目录.", this);
                    return;
                }
            }
            if (openfiledialog.ShowDialog(this) == DialogResult.OK)
            {
                m_textboxUseUiSettings.Text = Path.GetFileName(openfiledialog.FileName);
                m_twaincstoolkit.RestoreSnapshot(Path.Combine(m_szSettingsFolder, m_textboxUseUiSettings.Text));

                SaveSetting("settingfile", m_textboxUseUiSettings.Text);
            }
        }

        /// <summary>
        /// Keep us updated with changes to the save image path...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_textboxFolder_TextChanged(object sender, EventArgs e)
        {
            m_twaincstoolkit.SetImagePath(m_textboxFolder.Text, 0);
            SaveFolder(m_textboxFolder.Text);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////
        // Private Attributes...
        ///////////////////////////////////////////////////////////////////////////////
        #region Private Attributes...

        /// <summary>
        /// The folder we persist data to...
        /// </summary>
        private string m_szTwainscanFolder;

        /// <summary>
        /// The settings folder...
        /// </summary>
        private string m_szSettingsFolder;

        /// <summary>
        /// Access to the TWAIN driver...
        /// </summary>
        private TWAINCSToolkit m_twaincstoolkit;


        #endregion

        private void FormSetup_Load(object sender, EventArgs e)
        {

        }

        private void rbLocate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoading) return;
                if ((sender as RadioButton).Checked == false) return;

 
                bool result = SetTwainTransferMode((sender as Control).Tag.ToString());

                if (result == false)
                {
                    MessageBox.Show("当前模式不支持。");
                    return;
                }
                 
                SaveSetting("transfermode", (sender as Control).Tag.ToString());
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 设置当前传输模式
        /// </summary>
        /// <param name="transferMode"></param>
        /// <returns></returns>
        private bool SetTwainTransferMode(string transferMode)
        {
            string szTwmemref = "ICAP_XFERMECH";
            string szStatus = "";
            TWAIN.STS sts;

            sts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_GETCURRENT", ref szTwmemref, ref szStatus);

            string[] pros = (szTwmemref + "").Split(',');
            pros[3] = transferMode;


            szTwmemref = String.Join(",", pros);
            sts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_SET", ref szTwmemref, ref szStatus);

            return (sts == TWAIN.STS.SUCCESS) ? true : false;
        }

        /// <summary>
        /// 获取当前传输模式
        /// </summary>
        /// <returns></returns>
        private string GetTwainTransferMode()
        {
            string szTwmemref = "ICAP_XFERMECH";
            string szStatus = "";

            TWAIN.STS sts = m_twaincstoolkit.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_GETCURRENT", ref szTwmemref, ref szStatus);

            string[] pros = (szTwmemref + ",,,,").Split(',');

            return pros[3];
        }
    }
}
