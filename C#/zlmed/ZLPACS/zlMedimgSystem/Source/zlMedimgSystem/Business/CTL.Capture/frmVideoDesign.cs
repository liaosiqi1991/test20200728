using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.Design;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Capture
{
    public partial class frmVideoDesign : Form
    {
        private bool _isOk = false;
        private CaptureModuleDesign _captureDesign = null;
        public frmVideoDesign()
        {
            InitializeComponent();
        }

        public bool ShowDesign(CaptureModuleDesign captureDesign, IWin32Window owner)
        {
            _captureDesign = captureDesign;

            toolsConfig1.InitToolDesign(_captureDesign.ToolsDesign);

            this.ShowDialog(owner);

            return _isOk;
        }
         
        private void frmVideoDesign_Load(object sender, EventArgs e)
        {
            try
            {  

                cbxDockWay.SelectedIndex = (int)_captureDesign.Dock;
                                         
                chkCapture.Checked = _captureDesign.ButCaptureVisible;
                chkRecord.Checked = _captureDesign.ButRecordVisible;
                chkRestart.Checked = _captureDesign.ButRestartVisible;
                chkExit.Checked = _captureDesign.ButQuitVisible;
                chkSetting.Checked = _captureDesign.ButSettingVisible;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
         

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                toolsConfig1.ApplyUpdate();

                _captureDesign.Dock = (ToolDockWay)cbxDockWay.SelectedIndex;
                _captureDesign.ButCaptureVisible = chkCapture.Checked;
                _captureDesign.ButRecordVisible = chkRecord.Checked;
                _captureDesign.ButRestartVisible = chkRestart.Checked;
                _captureDesign.ButQuitVisible = chkExit.Checked;
                _captureDesign.ButSettingVisible = chkSetting.Checked;
                                
                _captureDesign.ToolsDesign = toolsConfig1.ToolsDesign;

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
