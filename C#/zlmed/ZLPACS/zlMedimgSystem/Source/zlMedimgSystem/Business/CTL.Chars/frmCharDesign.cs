using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Chars
{
    public partial class frmCharDesign : Form
    {
        private bool _isOk = false;
        private CharModuleDesign _chrModuleDesign = null;
        public frmCharDesign()
        {
            InitializeComponent();
        }

        public bool ShowDesign(CharModuleDesign chrModuleDesign, IWin32Window owner)
        {
            _chrModuleDesign = chrModuleDesign;

            toolsConfig1.InitToolDesign(_chrModuleDesign.ToolsDesign);

            this.ShowDialog(owner);

            return _isOk;
        }

        private void frmCharDesign_Load(object sender, EventArgs e)
        {
            try
            {

                chkSetting.Checked = _chrModuleDesign.ButSettingVisible; 
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

                _chrModuleDesign.ButSettingVisible = chkSetting.Checked; 

                _chrModuleDesign.ToolsDesign = toolsConfig1.ToolsDesign;

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
