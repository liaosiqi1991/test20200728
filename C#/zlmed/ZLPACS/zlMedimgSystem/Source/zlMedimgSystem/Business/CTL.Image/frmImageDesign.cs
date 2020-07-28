using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Image
{
    public partial class frmImageDesign : Form
    {
        private bool _isOk = false;
        private ImageModuleDesign _imgModuleDesign = null;
        public frmImageDesign()
        {
            InitializeComponent();
        }

        public bool ShowDesign(ImageModuleDesign imgModuleDesign, IWin32Window owner)
        {
            _imgModuleDesign = imgModuleDesign;

            toolsConfig1.InitToolDesign(_imgModuleDesign.ToolsDesign);

            this.ShowDialog(owner);

            return _isOk;
        }

        private void frmImageDesign_Load(object sender, EventArgs e)
        {
            try
            {

                chkImgRefresh.Checked = _imgModuleDesign.ButImgRefreshVisible; 
                chkImgSetting.Checked = _imgModuleDesign.ButImgSettingVisible;
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

                _imgModuleDesign.ButImgRefreshVisible = chkImgRefresh.Checked; 
                _imgModuleDesign.ButImgSettingVisible = chkImgSetting.Checked;

                _imgModuleDesign.ToolsDesign = toolsConfig1.ToolsDesign;

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
